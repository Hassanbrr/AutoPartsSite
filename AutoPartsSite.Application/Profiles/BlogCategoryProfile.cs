using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles;

public class BlogCategoryProfile : Profile

{
    public BlogCategoryProfile()
    {
        CreateMap<BlogCategory, BlogCategoryDto>()
            .ForMember(dest => dest.ParentCategoryName,
                opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : "ندارد"));
        CreateMap<BlogCategoryDto, BlogCategory>()
            .ForMember(dst => dst.ChildCategories, opt => opt.Ignore());


    }

}