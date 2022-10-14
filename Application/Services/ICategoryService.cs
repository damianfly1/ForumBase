using Application.DTOs;
using Domain.Models.Entities;

namespace Application.Services;

public interface ICategoryService
{
    public Task<Category> CreateCategory(Guid forumId, CreateCategoryDto model);
}
