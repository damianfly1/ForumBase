using Application.DTOs.Forum;

namespace Application.Services;

public interface IForumService
{
    public Task<ForumNestedResponseDto> GetForumNested(Guid id);
    public Task<ForumResponseDto> UpdateForum(Guid id, UpdateForumDto updateForumDto);
}
