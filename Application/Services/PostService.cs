using Application.DTOs.Category;
using Application.DTOs.Post;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IGenericRepository<Post> _postRepository;
    private readonly IGenericRepository<Topic> _topicRepository;
    private readonly IMapper _mapper;

    public PostService(IGenericRepository<Post> postRepository, IGenericRepository<Topic> topicRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    public async Task<PostResponseDto> AddPost(Guid topicId, CreatePostDto createPostDto)
    {
        var topic = await _topicRepository.GetById(topicId);
        Post post = new Post(createPostDto.Text, topic);
        var result = await _postRepository.Insert(post);
        await _postRepository.Save();
        return _mapper.Map<PostResponseDto>(result);
    }

    public async Task<PostResponseDto> DeletePost(Guid id)
    {
        var result = await _postRepository.Delete(id);
        await _postRepository.Save();
        return _mapper.Map<PostResponseDto>(result);
    }

    public async Task<PostResponseDto> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _postRepository.GetById(id);

        if (post is null) throw new Exception("Item not found");

        post.Text = updatePostDto.Text;
        post.LastUpdatedAt = DateTime.UtcNow;

        await _postRepository.Update(post);
        return _mapper.Map<PostResponseDto>(post);
    }
}
