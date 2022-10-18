using Application.DTOs.Topic;

namespace Application.Services;

public interface ITopicService
{
    public Task<TopicParentNestedResponseDto> GetTopicNested(Guid id);
    public Task<TopicResponseDto> AddTopic(Guid subForumId, CreateTopicDto createTopicDto);
    public Task<TopicResponseDto> UpdateTopic(Guid id, UpdateTopicDto updateTopicDto);
    public Task<TopicResponseDto> DeleteTopic(Guid id);
}
