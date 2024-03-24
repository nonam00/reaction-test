using AutoMapper;

using Backend.Domain;
using Application.Common.Mappings;

namespace Application.Results.Queries.GetResultList
{
	public class ResultVm : IMapWith<Result>
	{
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Result, ResultVm>()
				.ForMember(resultDto => resultDto.ReactionTime,
					opt => opt.MapFrom(note => note.ReactionTime))
				.ForMember(resultDto => resultDto.TestDate,
					opt => opt.MapFrom(note => note.TestDate));
		}
	}
}
