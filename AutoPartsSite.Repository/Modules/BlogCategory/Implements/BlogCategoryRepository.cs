using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.BlogCategory.Interfaces;

namespace AutoPartsSite.Repository.Modules.BlogCategory.Implements;

public class BlogCategoryRepository :Repository<Domain.BlogCategory>,IBlogCategoryRepository
{
    public BlogCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}