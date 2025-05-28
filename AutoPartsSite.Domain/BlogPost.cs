namespace AutoPartsSite.Domain;

public class BlogPost
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public string Content { get; private set; }
    public string FeaturedImage { get; private set; }
    public DateTime PublishDate { get; private set; }
    public string Slug { get; private set; }

    public int CategoryId { get;  set; }
    public BlogCategory Category { get; private set; }

    // سازنده اصلی برای ایجاد یک مقاله جدید


    public BlogPost()
    {

    }
}
