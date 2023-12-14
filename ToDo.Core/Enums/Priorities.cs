using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Enums;
public enum Priorities
{
    [Display(Name = "Low")]
    Low = 1,
    [Display(Name = "Medium")]
    Medium,
    [Display(Name = "High")]
    High
}
