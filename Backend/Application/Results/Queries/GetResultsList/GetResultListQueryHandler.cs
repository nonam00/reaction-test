using AutoMapper;
using MediatR;

using Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Results.Queries.GetResultsList
{
	public class GetResultListQueryHandler
		: IRequestHandler<GetResultListQuery, ResultListVm>
	{
		private readonly IResultsDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetResultListQueryHandler(IResultsDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ResultListVm> Handle(GetResultListQuery request,
			CancellationToken cancellationToken)
		{
			var resultsQuery = await _dbContext.Results
				.ProjectTo<ResultDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new ResultListVm { Results = resultsQuery };
		}
	}
}
