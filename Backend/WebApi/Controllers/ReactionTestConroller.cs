using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Application.Results.Commands.CreateResult;
using Application.Results.Queries.GetResultList;
using Application.Results.Queries.GetResultList.GetResultListByQuantity;
using Application.Results.Queries.GetResultList.GetWholeResultList;

using WebApi.Models;
using WebApi.Controllers;

namespace Backend.WebApi.Controllers
{
	[Produces("application/json")]
	public class ReactionTestController(IMapper mapper) : BaseController
	{
		private readonly IMapper _mapper = mapper;

		[HttpPost("add")]
		public async Task<ActionResult<Guid>> AddReactionTestResult
			([FromBody]CreateResultDto createResultDto)
		{
			var command = _mapper.Map<CreateResultCommand>(createResultDto);
			var resultId = await Mediator.Send(command);
			return Ok(resultId);
		}

		[HttpGet("get/all")]
		public async Task<ActionResult<ResultListVm>> GetAllReactionTestResults()
		{
			var query = new GetWholeResultListQuery { };
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("get/{quantity}")]
		public async Task<ActionResult<ResultListVm>> GetReactionTestResultsByCount(int quantity)
		{
			var query = new GetResultListByQuantityQuery
			{
				Quantity = quantity
			};

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}
	}
}