 
using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {

            CreateMap<BlogPost, BlogPostDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));


        }
    }

}
