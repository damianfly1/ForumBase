using Application.DTOs.SubForum;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;

namespace Application.Services;

public class SubForumService : ISubForumService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly ISubForumRepository _subForumRepository;
    private readonly IMapper _mapper;

    public SubForumService(IGenericRepository<Category> categoryRepository, ISubForumRepository subForumRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _subForumRepository = subForumRepository;
        _mapper = mapper;
    }

    public async Task<SubForumResponseDto> AddSubForum(Guid categoryId, CreateSubForumDto createSubForumDto)
    {
        var category = await _categoryRepository.GetById(categoryId);
        SubForum subForum = new SubForum(createSubForumDto.Name, createSubForumDto.Description, category);
        var result = await _subForumRepository.Insert(subForum);
        await _subForumRepository.Save();
        return _mapper.Map<SubForumResponseDto>(result);
    }

    public async Task<SubForumResponseDto> DeleteSubForum(Guid id)
    {
        var result = await _subForumRepository.Delete(id);
        await _subForumRepository.Save();
        return _mapper.Map<SubForumResponseDto>(result);
    }

    public async Task<SubForumParentNestedResponseDto> GetSubForumNested(Guid id)
    {
        var subForum = await _subForumRepository.GetNested(id);

        if (subForum is null) throw new Exception("Item not found");

        return _mapper.Map<SubForumParentNestedResponseDto>(subForum);
    }

    public async Task<SubForumResponseDto> UpdateSubForum(Guid id, UpdateSubForumDto updateSubForumDto)
    {
        var subForum = await _subForumRepository.GetById(id);

        if (subForum is null) throw new Exception("Item not found");

        subForum.Description = subForum.Description;
        subForum.Name = subForum.Name;
        subForum.LastUpdatedAt = DateTime.UtcNow;

        await _subForumRepository.Update(subForum);
        return _mapper.Map<SubForumResponseDto>(subForum);
    }
}
