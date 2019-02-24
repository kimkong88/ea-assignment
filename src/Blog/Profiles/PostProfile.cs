using System.Collections.Generic;
using Assignment.Blog.Dto;
using Assignment.Common.Helpers;
using Assignment.Data.Entities.Blog;
using AutoMapper;

namespace Assignment.Blog.Profiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<PostDto, Post>(MemberList.Source);
			CreateMap<Post, PostDto>()
				.ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => ConvertComments(src.Comments)));
		}

		private static IEnumerable<CommentDto> ConvertComments(IEnumerable<Comment> comments)
		{
			if (comments == null)
			{
				return new List<CommentDto>();
			}

			return Mapper.Instance.MapEnumerable<Comment, CommentDto>(comments);
		}
	}
}
