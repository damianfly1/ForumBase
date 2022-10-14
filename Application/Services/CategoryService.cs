using Application.DTOs;
using Domain.Models.Entities;
using Domain.Repositories;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IGenericRepository<Forum> _forumRepository;

    public CategoryService(IGenericRepository<Category> categoryRepository, IGenericRepository<Forum> forumRepository)
    {
        _categoryRepository = categoryRepository;
        _forumRepository = forumRepository;
    }

    public async Task<Category> CreateCategory(Guid forumId, CreateCategoryDto model)
    {
        var forum = await _forumRepository.GetById(forumId);

        Category category = new Category(model.Name, forum, model.Description);
        var result = _categoryRepository.Insert(category);
        await _categoryRepository.Save();
        return result;
        
    }
}
