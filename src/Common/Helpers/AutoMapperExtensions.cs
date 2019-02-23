using System.Collections.Generic;
using AutoMapper;

namespace Assignment.Common.Helpers
{
	public static class AutoMapperExtensions
	{
		public static IEnumerable<TDestination> MapEnumerable<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> source)
		{
			var mappedResult = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
			return mappedResult;
		}
	}
}
