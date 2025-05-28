namespace AutoPartsSite.Domain;

public class BlogCategory
{
    public int Id { get; set; } // قبلاً private بود
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public int? ParentCategoryId { get; set; }
    public BlogCategory ParentCategory { get; set; }
    public ICollection<BlogCategory> ChildCategories { get; set; } = new List<BlogCategory>();
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
   protected BlogCategory(){}
}