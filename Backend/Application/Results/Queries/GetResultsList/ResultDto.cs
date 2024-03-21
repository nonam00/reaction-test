using Backend.Domain;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Results.Queries.GetResultsList
{
	public class ResultDto : IMapWith<Result>
	{
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Result, ResultDto>()
				.ForMember(resultDto => resultDto.ReactionTime,
					opt => opt.MapFrom(note => note.ReactionTime))
				.ForMember(resultDto => resultDto.TestDate,
					opt => opt.MapFrom(note => note.TestDate));
		}
	}
}
