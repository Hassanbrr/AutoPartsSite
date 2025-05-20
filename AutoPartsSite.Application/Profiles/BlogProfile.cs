using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
         
            CreateMap<BlogPost, BlogPostDto>(); 
            CreateMap<BlogPostDto, BlogPost>()
                .ConstructUsing(dto => new BlogPost(
                    dto.Title, dto.Summary, dto.Content, dto.FeaturedImage,
                    dto.PublishDate));
        }
    }

}
