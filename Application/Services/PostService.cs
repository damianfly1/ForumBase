using Application.DTOs.Category;
using Application.DTOs.Post;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IGenericRepository<Topic> _topicRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public PostService(IPostRepository postRepository,
        IGenericRepository<Topic> topicRepository,
        IMapper mapper,
        UserManager<User> userManager)
    {
        _postRepository = postRepository;
        _topicRepository = topicRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<PostResponseDto> AddPost(Guid topicId, CreatePostDto createPostDto, string? name)
    {
        var topic = await _topicRepository.GetById(topicId);

        if (topic == null) throw new ApplicationException("NOT FOUND");

        var user = await _userManager.FindByNameAsync(name);

        Post post = new Post(createPostDto.Text, topic, user);
        post.LastUpdatedAt = DateTime.UtcNow;
        post.CreatedAt = DateTime.UtcNow;

        var result = await _postRepository.Insert(post);
        await _postRepository.Save();
        return _mapper.Map<PostResponseDto>(result);
    }

    public async Task DeletePost(Guid id)
    {
        var result = await _postRepository.Delete(id);
        await _postRepository.Save();
    }

    public async Task<PostResponseDto> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _postRepository.GetById(id);

        if (post is null) throw new ApplicationException("NOT FOUND");

        post.Text = updatePostDto.Text;
        post.LastUpdatedAt = DateTime.UtcNow;

        await _postRepository.Update(post);
        return _mapper.Map<PostResponseDto>(post);
    }

    public async Task<int> GetUserPostCount(string userId)
    {
        var number = await _postRepository.GetAll();
        return number.Where(x => x.AuthorId == userId).Count();
    }

    public async Task UpvotePost(Guid id, string? name)
    {
        var post = await _postRepository.GetWithLiked(id);

        var user = await _userManager.FindByNameAsync(name);

        if (post.LikedBy.FirstOrDefault(x => x.UserId==user.Id) != null) throw new ApplicationException("BAD REQUEST");

        if (post is null) throw new ApplicationException("NOT FOUND");

        post.Points++;
        user.LikedPosts.Add(new LikedPosts
        {
            User = user,
            UserId = user.Id,
            Post = post,
            PostId = post.Id,
        });

        await _postRepository.Update(post);
    }

    public async Task<int> GetUserReputation(string userId)
    {
        var allPosts = await _postRepository.GetAll();
        return allPosts.Where(x => x.AuthorId == userId).Sum(x => x.Points);
    }

    public async Task DownvotePost(Guid id, string? name)
    {
        var post = await _postRepository.GetWithLiked(id);

        var user = await _userManager.FindByNameAsync(name);

        if (post.LikedBy.FirstOrDefault(x => x.UserId == user.Id) == null) throw new ApplicationException("BAD REQUEST");

        if (post is null) throw new ApplicationException("NOT FOUND");

        post.Points--;
        post.LikedBy.Remove(post.LikedBy.First(x => x.UserId==user.Id));

        await _postRepository.Update(post);
    }
}
