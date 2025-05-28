using AutoPartsSite.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsSite.Presentation.Web.Infrastructure.Helps;

public static class CategoryTreeHelper
{
    public static List<SelectListItem> BuildCategorySelectList(IEnumerable<BlogCategoryDto> categories, int? parentId = null, string prefix = "")
    {
        var result = new List<SelectListItem>();

        var children = categories.Where(c => c.ParentCategoryId == parentId).OrderBy(c => c.Name);
        foreach (var child in children)
        {
            result.Add(new SelectListItem
            {
                Value = child.Id.ToString(),
                Text = prefix + child.Name
            });

            result.AddRange(BuildCategorySelectList(categories, child.Id, prefix + "— "));
        }

        return result;
    }
}
