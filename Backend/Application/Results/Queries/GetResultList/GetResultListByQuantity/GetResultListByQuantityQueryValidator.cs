using FluentValidation;

namespace Application.Results.Queries.GetResultList.GetResultListByQuantity
{
	public class GetResultListByQuantityQueryValidator
		: AbstractValidator<GetResultListByQuantityQuery>
	{
		public GetResultListByQuantityQueryValidator()
		{
			RuleFor(command => command.Quantity).GreaterThanOrEqualTo(1);
		}
	}
}
