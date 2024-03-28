using MediatR;

namespace Application.Results.Queries.GetResultList.GetResultListByQuantity
{
	public class GetResultListByQuantityQuery : IRequest<ResultListVm>
	{
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
	}
}
