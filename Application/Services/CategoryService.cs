using Application.DTOs.Category;
using Application.DTOs.Forum;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IGenericRepository<Forum> _forumRepository;
    private readonly IMapper _mapper;

    public CategoryService(
        IGenericRepository<Category> categoryRepository, 
        IGenericRepository<Forum> forumRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _forumRepository = forumRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponseDto> AddCategory(Guid forumId, CreateCategoryDto model)
    {
        var forum = await _forumRepository.GetById(forumId);

        if(forum == null) throw new ApplicationException("NOT FOUND");

        Category category = new Category(model.Name, forum, model.Description);
        var result = await _categoryRepository.Insert(category);
        await _categoryRepository.Save();
        return _mapper.Map<CategoryResponseDto>(result);
    }

    public async Task DeleteCategory(Guid id)
    {
        var result = await _categoryRepository.Delete(id);
        await _categoryRepository.Save();
    }

    public async Task<CategoryResponseDto> UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null) throw new ApplicationException("NOT FOUND");

        category.Description = updateCategoryDto.Description;
        category.Name = updateCategoryDto.Name;
        category.IsModerationOnly = updateCategoryDto.IsModerationOnly;
        category.LastUpdatedAt = DateTime.UtcNow;

        await _categoryRepository.Update(category);
        return _mapper.Map<CategoryResponseDto>(category);
    }
}
