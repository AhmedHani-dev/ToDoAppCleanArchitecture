namespace ToDo.Application.Dtos.Responses;

public class GetAllToDoEntriesResponse
{
    public List<ToDoListEntry> ToDoEntries { get; set; }
}

public class ToDoListEntry
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string? Priority { get; set; }
    public bool IsCompleted { get; set; }
}
