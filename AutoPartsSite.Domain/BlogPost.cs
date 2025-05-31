using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using AutoPartsSite.Domain.Common;

namespace AutoPartsSite.Domain;

public class BlogPost : ISlugEntity
{
    public int Id { get;  set; }
    public string Title { get;  set; }
    public string Summary { get;  set; }
    public string Content { get;  set; }
    [ValidateNever]
    public string FeaturedImage { get;  set; }
    public DateTime PublishDate { get;  set; }
    public string Slug { get;  set; }

    public int CategoryId { get;  set; }
    public BlogCategory Category { get;  set; }

    // سازنده اصلی برای ایجاد یک مقاله جدید

    public string GetSlugSource() => Title;
}
