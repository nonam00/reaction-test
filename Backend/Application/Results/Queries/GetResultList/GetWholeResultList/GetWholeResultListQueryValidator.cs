using FluentValidation;

namespace Application.Results.Queries.GetResultList.GetWholeResultList
{
    public class GetWholeResultListQueryValidator
        : AbstractValidator<GetWholeResultListQuery>
    {
        public GetWholeResultListQueryValidator()
        {
           RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
