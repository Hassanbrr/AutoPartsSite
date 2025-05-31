using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Domain.Common;
using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AutoPartsSite.Application.Services;
public class SlugService : ISlugService
{
    public string GenerateSlug(string input)
    {
        var slug = input.ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("---", "-")
            .Replace("--", "-");

        slug = Regex.Replace(slug, @"[^a-z0-9\-ا-ی]", "");
        slug = Regex.Replace(slug, @"-+", "-").Trim('-');

        return slug;
    }

    public async Task<string> GenerateUniqueSlugAsync<T>(string input, Func<string, Task<bool>> isSlugExist) where T : ISlugEntity
    {
        var baseSlug = GenerateSlug(input);
        var slug = baseSlug;
        int i = 1;

        while (await isSlugExist(slug))
        {
            slug = $"{baseSlug}-{i++}";
        }

        return slug;
    }
}