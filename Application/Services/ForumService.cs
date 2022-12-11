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
    
    public async Task<ForumNestedResponseDto> GetForumNested()
    {
        var forum = await _forumRepository.GetNested();

        if(forum is null) throw new ApplicationException("NOT FOUND");
        
        return _mapper.Map<ForumNestedResponseDto>(forum);
    }
}
