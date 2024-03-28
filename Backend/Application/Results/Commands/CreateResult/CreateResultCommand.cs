using MediatR;

namespace Application.Results.Commands.CreateResult
{
	public class CreateResultCommand : IRequest<Guid>
	{
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }
	}
}
