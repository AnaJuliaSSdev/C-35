using AutoMapper;
using ToDoList.Dtos;
using ToDoList.Models;

namespace ToDoList.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<ToDo, CreateToDoDto>();
        CreateMap<CreateToDoDto, ToDo>();
        CreateMap<ToDo, IListToDosDto>();
        CreateMap<ToDo, ListMobileToDosDto>();
        CreateMap<ToDo, ListWebToDosDto>();
        CreateMap<UpdateToDoDto, ToDo>();
    }
}
