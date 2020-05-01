using AutoMapper;
using JuniorForever.Domain.Models;
using JuniorForever.Dtos;

namespace JuniorForever.Helpers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Post, PostDto>()
                .ReverseMap();
            CreateMap<Author, AuthorDto>()
                .ReverseMap();
            CreateMap<Rating, RatingDto>()
                .ReverseMap();
        }
    }
}