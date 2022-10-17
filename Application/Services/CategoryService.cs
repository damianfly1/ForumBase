using Application.DTOs.Category;
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
        Category category = new Category(model.Name, forum, model.Description);
        var result = await _categoryRepository.Insert(category);
        await _categoryRepository.Save();
        return _mapper.Map<CategoryResponseDto>(result);
        
    }

    public async Task<CategoryResponseDto> DeleteCategory(Guid categoryId)
    {
        var result = _categoryRepository.Delete(categoryId);
        await _categoryRepository.Save();
        return _mapper.Map<CategoryResponseDto>(result);
    }
}
