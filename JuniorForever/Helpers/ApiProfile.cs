using AutoMapper;
using JuniorForever.Api.Dtos;
using JuniorForever.Domain.Models;

namespace JuniorForever.Api.Helpers
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