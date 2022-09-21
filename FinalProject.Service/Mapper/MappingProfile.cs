using AutoMapper;
using FinalProject.Dto;
using FinalProject.Data;
using System.Security.Principal;

namespace FinalProject.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap();

        }

    }
}