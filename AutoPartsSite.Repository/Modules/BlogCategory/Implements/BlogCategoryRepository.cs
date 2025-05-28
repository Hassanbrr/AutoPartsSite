using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.BlogCategory.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsSite.Repository.Modules.BlogCategory.Implements;

public class BlogCategoryRepository :Repository<Domain.BlogCategory>,IBlogCategoryRepository
{
    public BlogCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Domain.BlogCategory?> GetCategoryWithChildrenAndPostsAsync(int id)
    {
        return await _context.BlogCategories
            .Include(c => c.ChildCategories)
            .Include(c => c.BlogPosts)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}