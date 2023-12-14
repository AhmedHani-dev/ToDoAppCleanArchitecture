using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialModel : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Entries",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Priority = table.Column<int>(type: "int", nullable: false),
                IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Entries", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Entries");
    }
}
