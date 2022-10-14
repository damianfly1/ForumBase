using API.Models;
using Application.DTOs;
using AutoMapper;

namespace API.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CategoryCreateRequestModel, CreateCategoryDto>();
    }
}
