using Application.DTOs.Category;
using Application.DTOs.Forum;
using Application.DTOs.SubForum;
using AutoMapper;
using Domain.Models.Entities;

namespace Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //POST category
        CreateMap<Category, CategoryResponseDto>();

        //GET forum nested
        CreateMap<Forum, ForumNestedResponseDto>()
            .ForMember(f => f.Categories, opt => opt.MapFrom(c => c.Categories));
        CreateMap<Category, CategoryNestedResponseDto>()
            .ForMember(c => c.Subforums, opt => opt.MapFrom(s => s.Subforums));
        CreateMap<SubForum, SubforumNestedResponseDto>();

        //PUT forum
        CreateMap<Forum, ForumResponseDto>();
        CreateMap<UpdateForumDto, Forum>()
            .AfterMap((src, dest) => dest.LastUpdatedAt = DateTime.UtcNow);

    }
}
