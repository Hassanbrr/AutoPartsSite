using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Repository.Modules.BlogCategory.Interfaces;

public interface IBlogCategoryRepository : IRepository<Domain.BlogCategory>
{
    Task<Domain.BlogCategory?> GetCategoryWithChildrenAndPostsAsync(int id);
}