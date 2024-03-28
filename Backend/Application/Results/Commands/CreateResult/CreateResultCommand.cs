using MediatR;

namespace Application.Results.Commands.CreateResult
{
	public class CreateResultCommand : IRequest<Guid>
	{
		public Guid UserId { get; set; }
		public int ReactionTime { get; set; }
		public DateTime TestDate { get; set; }
	}
}
