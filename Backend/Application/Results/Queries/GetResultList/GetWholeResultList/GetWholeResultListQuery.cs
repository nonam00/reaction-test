using MediatR;

namespace Application.Results.Queries.GetResultList.GetWholeResultList
{
	public class GetWholeResultListQuery : IRequest<ResultListVm>
	{
        public Guid UserId { get; set; }
    }
}
