using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDo.Application.Dtos.Requests;
using ToDo.Application.Dtos.Responses;
using ToDo.Application.Extensions;
using ToDo.Application.Interfaces.Data;
using ToDo.Application.Interfaces.Services;
using ToDo.Core.Entities;

namespace ToDo.Application.Services;

public class ToDoEntriesService : IToDoEntriesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ToDoEntriesService> _logger;
    private readonly IMapper _mapper;

    public ToDoEntriesService(IUnitOfWork unitOfWork, ILogger<ToDoEntriesService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<GetAllToDoEntriesResponse> GetAllToDoEntries()
    {
        _logger.LogInformation("Started Getting all todo entries");

        var toDoEntries = await _unitOfWork.ToDoEntriesRepository
            .GetAll()
            .AsNoTracking()
            .ToListAsync();

        var toDoListEntries = toDoEntries
            .Select(e => _mapper.Map<ToDoListEntry>(e))
            .ToList();

        _logger.LogInformation($"Finished Getting {toDoListEntries.Count} todo entries");

        return new GetAllToDoEntriesResponse() { ToDoEntries = toDoListEntries };
    }

    public async Task<bool> InsertToDoEntry(InsertToDoEntryRequest request)
    {
        _logger.LogInformation("Started inserting a todo entry");

        _unitOfWork.ToDoEntriesRepository.Insert(new ToDoEntry()
        {
            Text = request.Text,
            Priority = request.Priority,
            IsCompleted = false,
            IsDeleted = false
        });

        bool insertedSuccessfully = await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation($"Finished inserting a todo entry with save status: {insertedSuccessfully}");

        return insertedSuccessfully;
    }

    public async Task<bool> DeleteToDoEntry(int id)
    {
        _logger.LogInformation($"Started deleting a todo entry with id: {id}");

        var todoEntry = await _unitOfWork.ToDoEntriesRepository.GetById(id);

        if (todoEntry == null)
            return false;

        _unitOfWork.ToDoEntriesRepository.Delete(todoEntry);

        bool deletedSuccessfully = await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation($"Finished deleting a todo entry with delete status: {deletedSuccessfully}");

        return deletedSuccessfully;
    }

    public async Task<bool> CloseToDoEntry(int id)
    {
        _logger.LogInformation($"Started closing a todo entry with id: {id}");

        var todoEntry = await _unitOfWork.ToDoEntriesRepository.GetById(id);

        if (todoEntry == null || todoEntry.IsCompleted)
            return false;

        todoEntry.IsCompleted = true;

        bool closedSuccessfully = await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation($"Finished closing a todo entry with close status: {closedSuccessfully}");

        return closedSuccessfully;
    }
}
