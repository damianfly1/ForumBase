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

        //POST PUT category
        CreateMap<Category, CategoryResponseDto>();

        //GET subforum nested
        CreateMap<SubForum, SubForumParentNestedResponseDto>()
            .ForMember(sf => sf.Topics, opt => opt.MapFrom(t => t.Topics));
        CreateMap<Topic, TopicNestedResponseDto>()
            .ForMember(t => t.ResponseCount, o => o.MapFrom(x => x.Posts.Count));

        //POST PUT subforum
        CreateMap<SubForum, SubForumResponseDto>();

        //GET topic nested
        CreateMap<Topic, TopicParentNestedResponseDto>()
            .ForMember(t => t.Posts, opt => opt.MapFrom(p => p.Posts));
        CreateMap<Post, PostNestedResponseDto>()
            .ForMember(x => x.LikedBy, opt => opt.MapFrom(lp => lp.LikedBy));

        CreateMap<LikedPosts, LikedByDto>();
        
            

        //POST PUT topic
        CreateMap<Topic, TopicResponseDto>();

        //POST PUT category
        CreateMap<Post, PostResponseDto>();

        //REGISTER user
        CreateMap<UserRegistrationDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

        //GET user
        CreateMap<User, UserResponseDto>();
    }
}
