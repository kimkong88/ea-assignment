using Assignment.Blog.Dto;
using Assignment.Data.Entities.Blog;
using AutoMapper;

namespace Assignment.Blog.Profiles
{
	public class AuthorProfile : Profile
	{
		public AuthorProfile()
		{
			CreateMap<AuthorDto, Author>();
			CreateMap<Author, AuthorDto>();
		}
	}
}
