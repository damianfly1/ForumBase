using Application.DTOs.Post;

namespace Application.Services;

public interface IPostService
{
    public Task<PostResponseDto> AddPost(Guid topicId, CreatePostDto createPostDto, string? name);
    public Task<PostResponseDto> UpdatePost(Guid id, UpdatePostDto updatePostDto);
    public Task DeletePost(Guid id);
    public Task<int> GetUserPostCount(string userId);
    public Task UpvotePost(Guid id, string? name);
    public Task<int> GetUserReputation(string id);
    Task DownvotePost(Guid id, string? name);
}
