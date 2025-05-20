namespace AutoPartsSite.Application.DTOs
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public DateTime PublishDate { get; set; } 
    }

}
