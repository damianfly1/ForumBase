using Application.DTOs.Category;
using Domain.Models.Entities;

namespace Application.Services;

public interface ICategoryService
{
    public Task<CategoryResponseDto> AddCategory(Guid forumId, CreateCategoryDto model);
    public Task<CategoryResponseDto> DeleteCategory(Guid categoryId);
}
