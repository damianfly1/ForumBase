using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class ForumService : IForumService
{
    private readonly IForumRepository _forumRepository;

    public ForumService(IForumRepository forumRepository)
    {
        _forumRepository = forumRepository;
    }

    public Task<Forum> GetForumNested(Guid id)
    {
        var forum = _forumRepository.GetNested(id);
        if(forum is null)
        {
            throw new Exception("Item not found");
        }
        return forum;
    }
}
