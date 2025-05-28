namespace AutoPartsSite.Domain;

public class BlogCategory
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }

    public int? ParentCategoryId { get; private set; }
    public BlogCategory ParentCategory { get; set; }

    // مجموعه فرزندان
    public ICollection<BlogCategory> ChildCategories { get; private set; } = new List<BlogCategory>();

    public ICollection<BlogPost> BlogPosts { get; private set; }
   protected BlogCategory(){}
}