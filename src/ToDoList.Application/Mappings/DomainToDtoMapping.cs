using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Assignment, AssignmentDTO>().ReverseMap();
        CreateMap<AssignmentList, AssignmentListDTO>().ReverseMap();
    }
}