using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Domain;
using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Application.Services;

public class BlogService : IBlogService
{
    private readonly IRepository<BlogPost> _blogRepository;
    private readonly IMapper _mapper;

    public BlogService(IRepository<BlogPost> blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BlogPostDto>> GetAllPostsAsync()
    {
        var posts = await _blogRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BlogPostDto>>(posts);
    }

    public async Task<BlogPostDto> GetPostByIdAsync(int id)
    {
        var post = await _blogRepository.GetByIdAsync(id);
        return post == null ? null : _mapper.Map<BlogPostDto>(post);
    }

    public async Task AddPostAsync(BlogPostDto postDto)
    {
        var post = _mapper.Map<BlogPost>(postDto);
        await _blogRepository.AddAsync(post);
        await _blogRepository.SaveChangesAsync();
    }

    public async Task UpdatePostAsync(BlogPostDto postDto)
    {
        var post = await _blogRepository.GetByIdAsync(postDto.Id);
        if (post == null) return;
        _mapper.Map(postDto, post);
        _blogRepository.Update(post);
        await _blogRepository.SaveChangesAsync();

    }

    public async Task DeletePostAsync(int id)
    {
        var post = await _blogRepository.GetByIdAsync(id);
        if (post == null) return;
        _blogRepository.Remove(post);
        await _blogRepository.SaveChangesAsync();

    }
}
