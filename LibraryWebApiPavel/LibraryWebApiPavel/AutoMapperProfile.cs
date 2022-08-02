using AutoMapper;
using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Dtos;
using LibraryWebApiPavel.Models;

namespace LibraryWebApiPavel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            
        }
    }
}