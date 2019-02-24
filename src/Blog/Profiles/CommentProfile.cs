using Assignment.Blog.Dto;
using Assignment.Data.Entities.Blog;
using AutoMapper;

namespace Assignment.Blog.Profiles
{
	public class CommentProfile : Profile
	{
		public CommentProfile()
		{
			CreateMap<CommentDto, Comment>();
			CreateMap<Comment, CommentDto>().
				ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
		}
	}
}
