using AutoMapper;
using System.ComponentModel.DataAnnotations;

using Application.Common.Mappings;
using Application.Results.Commands.CreateResult;

namespace WebApi.Models
{
	public class CreateResultDto : IMapWith<CreateResultCommand>
	{
		[Required]
		public int ReactionTime { get; set; }
        [Required]
        public DateTime TestDate { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateResultDto, CreateResultCommand>()
				.ForMember(resultCommand => resultCommand.ReactionTime,
					opt => opt.MapFrom(resultDto => resultDto.ReactionTime))
				.ForMember(resultCommand => resultCommand.TestDate,
					opt => opt.MapFrom(resultDto => resultDto.TestDate));
		}
	}
}
