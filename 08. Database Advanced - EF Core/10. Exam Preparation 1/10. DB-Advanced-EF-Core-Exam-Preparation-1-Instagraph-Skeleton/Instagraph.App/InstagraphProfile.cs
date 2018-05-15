using AutoMapper;
using Instagraph.DataProcessor.DTOs;
using Instagraph.Models;

namespace Instagraph.App
{ 
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<Post, PostExportDto>()
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture.Path))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<User, UserExportDto>()
                .ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers.Count));

            //CreateMap<User, UserMostCommentsDto>()
            //    .ForMember(dest => dest.MostComments, opt => opt.MapFrom(src => src.Posts
            //        .OrderByDescending(p => p.Comments.Count)
            //        .FirstOrDefault()
            //        .Comments.Count));
        }
    }
}
