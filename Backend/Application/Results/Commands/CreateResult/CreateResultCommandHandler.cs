using MediatR;

using Backend.Domain;
using Application.Interfaces;

namespace Application.Results.Commands.CreateResult
{
	public class CreateResultCommandHandler(IResultsDbContext dbContext)
		: IRequestHandler<CreateResultCommand, Guid>
	{
		private readonly IResultsDbContext _dbContext = dbContext;

		public async Task<Guid> Handle(CreateResultCommand request,
			CancellationToken cancellationToken)
		{
			var result = new Result
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				ReactionTime = request.ReactionTime,
				TestDate = request.TestDate
			};

			await _dbContext.Results.AddAsync(result, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return result.Id;
		}
	}
}
