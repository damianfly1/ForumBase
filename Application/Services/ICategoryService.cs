using Application.DTOs.Category;
using Domain.Models.Entities;

namespace Application.Services;

public interface ICategoryService
{
    public Task<CategoryResponseDto> AddCategory(Guid forumId, CreateCategoryDto createCategoryDto);
    public Task<CategoryResponseDto> UpdateCategory(Guid Id, UpdateCategoryDto updateCategoryDto);
    public Task<CategoryResponseDto> DeleteCategory(Guid Id);
}
