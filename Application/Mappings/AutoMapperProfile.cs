using Application.DTOs.Category;
using Application.DTOs.Forum;
using Application.DTOs.Post;
using Application.DTOs.SubForum;
using Application.DTOs.Topic;
using Application.DTOs.User;
using AutoMapper;
using Domain.Models.Entities;

namespace Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {   
        //GET forum nested
        CreateMap<Forum, ForumNestedResponseDto>()
            .ForMember(f => f.Categories, opt => opt.MapFrom(c => c.Categories));
        CreateMap<Category, CategoryNestedResponseDto>()
            .ForMember(c => c.Subforums, opt => opt.MapFrom(s => s.Subforums));
        CreateMap<SubForum, SubForumNestedResponseDto>();

        //PUT forum
        CreateMap<Forum, ForumResponseDto>();

        //POST PUT DELETE category
        CreateMap<Category, CategoryResponseDto>();

        //GET subforum nested
        CreateMap<SubForum, SubForumParentNestedResponseDto>()
            .ForMember(sf => sf.Topics, opt => opt.MapFrom(t => t.Topics));
        CreateMap<Topic, TopicNestedResponseDto>();

        //POST PUT DELETE subforum
        CreateMap<SubForum, SubForumResponseDto>();

        //GET topic nested
        CreateMap<Topic, TopicParentNestedResponseDto>()
            .ForMember(t => t.Posts, opt => opt.MapFrom(p => p.Posts));
        CreateMap<Post, PostNestedResponseDto>();

        //POST PUT DELETE topic
        CreateMap<Topic, TopicResponseDto>();

        //POST PUT DELETE category
        CreateMap<Post, PostResponseDto>();

        CreateMap<UserRegistrationDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
