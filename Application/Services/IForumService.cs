using Application.DTOs.Forum;

namespace Application.Services;

public interface IForumService
{
    public Task<ForumNestedResponseDto> GetForumNested();
}
