using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using Application.Interfaces;

namespace Application.Results.Queries.GetResultList.GetWholeResultList
{
	public class GetWholeResultListQueryHandler : IRequestHandler<GetWholeResultListQuery, ResultListVm>
	{
		private readonly IResultsDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetWholeResultListQueryHandler(IResultsDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public async Task<ResultListVm> Handle(GetWholeResultListQuery request,
			CancellationToken cancellationToken)
		{
			var resultsQuery = await _dbContext.Results
				.Where(result => result.UserId == request.UserId)
				.ProjectTo<ResultVm>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new ResultListVm { Results = resultsQuery };
		}
	}
}
