using AutoMapper;
using BookStoreAPI.Models;
using BookStoreAPI.Models.Dto;

namespace BookStoreAPI;
public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<Book, BooksDto>().ReverseMap();
        });

        return mapperConfig;
    }
}