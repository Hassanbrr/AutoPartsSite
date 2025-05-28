using AutoPartsSite.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class BlogCategoryTreeHelper
{
    public static List<SelectListItem> BuildCategoryTree(List<BlogCategoryDto> categories, int? selectedId = null, int? excludeId = null)
    {
        var list = new List<SelectListItem>();
        BuildRecursive(null, "", categories, list, selectedId, excludeId);
        return list;
    }

    private static void BuildRecursive(int? parentId, string prefix, List<BlogCategoryDto> categories, List<SelectListItem> result, int? selectedId, int? excludeId)
    {
        var children = categories
            .Where(c => c.ParentCategoryId == parentId)
            .OrderBy(c => c.Name)
            .ToList();

        foreach (var category in children)
        {
            if (excludeId != null && category.Id == excludeId)
                continue;

            result.Add(new SelectListItem
            {
                Text = $"{prefix}{category.Name}",
                Value = category.Id.ToString(),
                Selected = selectedId == category.Id
            });

            BuildRecursive(category.Id, prefix + "— ", categories, result, selectedId, excludeId);
        }
    }
}