using ToDo.Application.Dtos.Requests;
using ToDo.Application.Dtos.Responses;

namespace ToDo.Application.Interfaces.Services;

public interface IToDoEntriesService
{
    public Task<GetAllToDoEntriesResponse> GetAllToDoEntries();
    public Task<bool> InsertToDoEntry(InsertToDoEntryRequest request);
    public Task<bool> DeleteToDoEntry(int id);
    public Task<bool> CloseToDoEntry(int id);
}
