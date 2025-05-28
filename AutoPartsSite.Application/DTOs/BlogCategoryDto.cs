namespace AutoPartsSite.Application.DTOs
{
    public class BlogCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; } // نمایش نام والد

        public IList<BlogCategoryDto>? Children { get; set; } // برای نمایش
    }
}