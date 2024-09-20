using AutoMapper;
using Labb_LibraryApi.Data;
using Labb_LibraryApi.Models.DTOs;

namespace Labb_LibraryApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<Book, UpdateBookDTO>().ReverseMap();
        }
    }
}
