using Application.DTOs.Post;

namespace Application.Services;

public interface IPostService
{
    public Task<PostResponseDto> AddPost(Guid topicId, CreatePostDto createPostDto);
    public Task<PostResponseDto> UpdatePost(Guid id, UpdatePostDto updatePostDto);
    public Task<PostResponseDto> DeletePost(Guid id);
}
