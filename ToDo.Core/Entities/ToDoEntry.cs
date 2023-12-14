using ToDo.Core.Enums;

namespace ToDo.Core.Entities;

public class ToDoEntry : ISoftDelete
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Priorities Priority { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }
}
