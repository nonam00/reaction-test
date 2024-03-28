﻿using FluentValidation;

namespace Application.Results.Commands.CreateResult
{
	public class CreateResultCommandValidation : AbstractValidator<CreateResultCommand>
	{
		public CreateResultCommandValidation()
		{
			RuleFor(createResult =>
				createResult.TestDate).NotEmpty();
			RuleFor(createResult =>
				createResult.ReactionTime).GreaterThan(0);
		}
	}
}
