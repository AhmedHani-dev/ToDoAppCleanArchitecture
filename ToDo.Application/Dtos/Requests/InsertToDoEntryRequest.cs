using System.ComponentModel.DataAnnotations;
using ToDo.Core.Enums;

namespace ToDo.Application.Dtos.Requests;
public class InsertToDoEntryRequest
{
    [Required]
    public string? Text { get; set; }
    [EnumDataType(typeof(Priorities))]
    public Priorities Priority { get; set; }
}
