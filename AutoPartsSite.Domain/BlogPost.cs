namespace AutoPartsSite.Domain;

public class BlogPost
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public string Content { get; private set; }
    public string FeaturedImage { get; private set; }
    public DateTime PublishDate { get; private set; }

 

    // سازنده اصلی برای ایجاد یک مقاله جدید
    public BlogPost(string title, string summary, string content, string featuredImage, DateTime publishDate)
    {
        Title = title;
        Summary = summary;
        Content = content;
        FeaturedImage = featuredImage;
        PublishDate = publishDate;
 
    } 

 
}
