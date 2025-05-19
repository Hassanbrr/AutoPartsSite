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
            // نگاشت از موجودیت Domain BlogPost به BlogPostDto
            CreateMap<BlogPost, BlogPostDto>();
             

            // نگاشت معکوس را نیز در صورت نیاز اضافه کنید
            CreateMap<BlogPostDto, BlogPost>()
                .ConstructUsing(dto => new BlogPost(
                    dto.Title, dto.Summary, dto.Content, dto.FeaturedImage,
                    dto.PublishDate));
        }
    }

}
