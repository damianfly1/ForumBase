using Application.DTOs.Forum;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;

namespace Application.Services;

public class ForumService : IForumService
{
    private readonly IForumRepository _forumRepository;
    private readonly IMapper _mapper;

    public ForumService(IForumRepository forumRepository, IMapper mapper)
    {
        _forumRepository = forumRepository;
        _mapper = mapper;
    }
    
    public async Task<ForumNestedResponseDto> GetForumNested(Guid id)
    {
        var forum = await _forumRepository.GetNested(id);

        if(forum is null) throw new Exception("Item not found");
        
        return _mapper.Map<ForumNestedResponseDto>(forum);
    }

    public async Task<ForumResponseDto> UpdateForum(Guid id, UpdateForumDto updateForumDto)
    {
        var forum = await _forumRepository.GetById(id);

        if (forum is null) throw new Exception("Item not found");

        forum.Description = updateForumDto.Description;
        forum.Name = updateForumDto.Name;
        forum.Rules = updateForumDto.Rules;
        forum.Faq = updateForumDto.Faq;
        forum.LastUpdatedAt = DateTime.UtcNow;

        await _forumRepository.Update(forum);
        await _forumRepository.Save();
        return _mapper.Map<ForumResponseDto>(forum);
    }
}
