using Application.DTOs;
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

    public async Task<Forum> GetForumNested(Guid id)
    {
        var forum = await _forumRepository.GetNested(id);
        if(forum is null)
        {
            throw new Exception("Item not found");
        }
        return forum;
    }

    public async Task<Forum> UpdateForum(Guid id, UpdateForumDto model)
    {
        var forum = await _forumRepository.GetById(id);
        if (forum is null)
        {
            throw new Exception("Item not found");
        }
        forum.Description = model.Description;
        forum.Name = model.Name;
        forum.Rules = model.Rules;
        forum.Faq = model.Faq;  

        await _forumRepository.Update(forum);
        await _forumRepository.Save();
        return forum;
    }
}
