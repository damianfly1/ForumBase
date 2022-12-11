using Application.DTOs.Topic;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class TopicService : ITopicService
{
    private readonly IGenericRepository<SubForum> _subForumRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public TopicService(IGenericRepository<SubForum> subForumRepository, 
        ITopicRepository topicRepository, 
        IMapper mapper, 
        UserManager<User> userManager)
    {
        _subForumRepository = subForumRepository;
        _topicRepository = topicRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<TopicResponseDto> AddTopic(Guid subForumId, CreateTopicDto createTopicDto, string name)
    {
        var subForum = await _subForumRepository.GetById(subForumId);

        if (subForum == null) throw new ApplicationException("NOT FOUND");

        var user = await _userManager.FindByNameAsync(name);

        Topic topic = new Topic(createTopicDto.Name, subForum, createTopicDto.IsPinned, createTopicDto.IsClosed, user);
        topic.LastUpdatedAt = DateTime.UtcNow;

        var result = await _topicRepository.Insert(topic);
        await _topicRepository.Save();
        return _mapper.Map<TopicResponseDto>(result);
    }

    public async Task DeleteTopic(Guid id)
    {

        var result = await _topicRepository.Delete(id);
        await _topicRepository.Save();
    }

    public async Task<TopicParentNestedResponseDto> GetTopicNested(Guid id)
    {
        var topic = await _topicRepository.GetNested(id);

        if (topic is null) throw new ApplicationException("NOT FOUND");

        topic.ViewCount += 1;

        await _topicRepository.Save();

        return _mapper.Map<TopicParentNestedResponseDto>(topic);
    }

    public async Task<TopicResponseDto> UpdateTopic(Guid id, UpdateTopicDto updateTopicDto)
    {
        var topic = await _topicRepository.GetById(id);

        if (topic is null) throw new ApplicationException("NOT FOUND");

        topic.Name = updateTopicDto.Name;
        topic.IsPinned = updateTopicDto.IsPinned;
        topic.IsClosed = updateTopicDto.IsClosed;
        topic.LastUpdatedAt = DateTime.UtcNow;

        await _topicRepository.Update(topic);
        return _mapper.Map<TopicResponseDto>(topic);
    }
}
