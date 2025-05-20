using AutoPartsSite.Application.DTOs;

namespace AutoPartsSite.Application.InterFaces;

public interface IBlogService
{
    Task<IEnumerable<BlogPostDto>> GetAllPostsAsync();
    Task<BlogPostDto> GetPostByIdAsync(int id);
    Task AddPostAsync(BlogPostDto postDto);
    Task UpdatePostAsync(BlogPostDto postDto);
    Task DeletePostAsync(int id);
}
