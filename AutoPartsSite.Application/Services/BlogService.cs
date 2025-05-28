using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Domain;
using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Application.Services;

public class BlogService : IBlogService
{
    private readonly IUnitOffWork _unitOffWork;
    private readonly IMapper _mapper;

    public BlogService(IUnitOffWork unitOffWork, IMapper mapper)
    {
        _unitOffWork = unitOffWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BlogPostDto>> GetAllPostsAsync()
    {
        var posts = await _unitOffWork.Blog.GetAllAsync("Category");
        return _mapper.Map<IEnumerable<BlogPostDto>>(posts);
    }

    public async Task<BlogPostDto> GetPostByIdAsync(int id)
    {
        var post = await _unitOffWork.Blog.GetByIdAsync(id);
        return post == null ? null : _mapper.Map<BlogPostDto>(post);
    }

    public async Task AddPostAsync(BlogPostDto postDto)
    {
        var post = _mapper.Map<BlogPost>(postDto);
        post.CategoryId = postDto.CategoryId;
        await _unitOffWork.Blog.AddAsync(post);
        await _unitOffWork.SaveChangesAsync();
    }

    public async Task UpdatePostAsync(BlogPostDto postDto)
    {
        var post = await _unitOffWork.Blog.GetByIdAsync(postDto.Id);
        if (post == null) return;
        _mapper.Map(postDto, post);
        post.CategoryId = postDto.CategoryId;

        _unitOffWork.Blog.Update(post);
        await _unitOffWork.SaveChangesAsync();

    }

    public async Task DeletePostAsync(int id)
    {
        var post = await _unitOffWork.Blog.GetByIdAsync(id);
        if (post == null) return;
        _unitOffWork.Blog.Remove(post);
        await _unitOffWork.SaveChangesAsync();

    }
}
