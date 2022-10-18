using Application.DTOs.SubForum;

namespace Application.Services;

public interface ISubForumService
{
    public Task<SubForumParentNestedResponseDto> GetSubForumNested(Guid id);
    public Task<SubForumResponseDto> AddSubForum(Guid categoryId, CreateSubForumDto createSubForumDto);
    public Task<SubForumResponseDto> UpdateSubForum(Guid id, UpdateSubForumDto updateSubForumDto);
    public Task<SubForumResponseDto> DeleteSubForum(Guid id);
}
