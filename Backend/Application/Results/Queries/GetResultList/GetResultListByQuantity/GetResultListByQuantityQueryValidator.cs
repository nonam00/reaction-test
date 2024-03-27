using FluentValidation;

namespace Application.Results.Queries.GetResultList.GetResultListByQuantity
{
	public class GetResultListByQuantityQueryValidator
		: AbstractValidator<GetResultListByQuantityQuery>
	{
		public GetResultListByQuantityQueryValidator()
		{
			RuleFor(query => query.UserId).NotEqual(Guid.Empty);
			RuleFor(query => query.Quantity).GreaterThanOrEqualTo(1);
		}
	}
}
