using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.BlogPost.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsSite.Repository.Modules.BlogPost.Implements;

public class BlogRepository : Repository<Domain.BlogPost>, IBlogRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Domain.BlogPost>> GetTopPostsAsync(int count)
    {
        return await _context.BlogPosts.OrderByDescending(p => p.PublishDate).Take(count).ToListAsync();
    }
}
