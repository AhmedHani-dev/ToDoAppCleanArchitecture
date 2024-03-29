﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Data;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        CreateGlobalIsDeletedQueryFilter(modelBuilder);
    }

    private void CreateGlobalIsDeletedQueryFilter(ModelBuilder modelBuilder)
    {
        modelBuilder.Model
            .GetEntityTypes()
            .ToList()
            .ForEach(et =>
            {
                // Check if the entity implements ISoftDelete
                if (typeof(ISoftDelete).IsAssignableFrom(et.ClrType))
                {
                    // Creates a parameter to be used in lambda expression ex: (e => e) e is the parameter
                    var parameter = Expression.Parameter(et.ClrType, "e");

                    // Creates the body to be used in creating a lambda expression
                    var body = Expression
                    .Equal(
                        Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, Expression.Constant(nameof(ISoftDelete.IsDeleted))),
                            Expression.Constant(false));

                    // Adds the global query filter
                    modelBuilder.Entity(et.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                }
            });
    }

    public DbSet<ToDoEntry> Entries { get; set; }
}
