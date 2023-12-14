using AutoMapper;
using ToDo.Application.Dtos.Responses;
using ToDo.Application.Extensions;
using ToDo.Core.Entities;

namespace ToDo.Application.AutoMapper;
public class ToDoEntryProfile : Profile
{
    public ToDoEntryProfile()
    {
        CreateMap<ToDoEntry, ToDoListEntry>()
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.GetDisplayName()));
    }
}
