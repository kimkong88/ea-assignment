using Assignment.Blog.Dto;
using Assignment.Data.Entities.Blog;
using AutoMapper;

namespace Assignment.Blog.Profiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<PostDto, Post>();
			CreateMap<Post, PostDto>();
		}
	}
}
