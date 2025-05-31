namespace AutoPartsSite.Domain.Common;

public interface ISlugEntity
{
    public string Title { get; }
    public string Slug { get; set; }
}
