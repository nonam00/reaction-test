using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using Application.Interfaces;

namespace Application.Results.Queries.GetResultList.GetResultListByQuantity
{
	public class GetResultListByQuantityQueryHandler : IRequestHandler<GetResultListByQuantityQuery, ResultListVm>
	{
		private readonly IResultsDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetResultListByQuantityQueryHandler(IResultsDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ResultListVm> Handle(GetResultListByQuantityQuery request,
			CancellationToken cancellationToken)
		{
			if (request.Quantity > _dbContext.Results.Count())
			{
				request.Quantity = _dbContext.Results.Count();
			}

			var resultsQuery = await _dbContext.Results
				.Where(result => result.UserId == request.UserId)
				.OrderByDescending(result => result.TestDate)
				.Take(request.Quantity)
				.ProjectTo<ResultVm>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new ResultListVm { Results = resultsQuery };
		}
	}
}
