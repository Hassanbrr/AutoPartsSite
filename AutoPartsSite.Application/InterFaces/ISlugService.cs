using AutoPartsSite.Domain.Common;
using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Application.InterFaces;

public interface ISlugService
{
    string GenerateSlug(string input);
    Task<string> GenerateUniqueSlugAsync<T>(string input, Func<string, Task<bool>> isSlugExist) where T : ISlugEntity;
}