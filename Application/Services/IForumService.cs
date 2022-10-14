using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public interface IForumService
{
    public Task<Forum> GetForumNested(Guid id);
}
