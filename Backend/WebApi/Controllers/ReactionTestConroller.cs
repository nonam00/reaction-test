using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Application.Results.Commands.CreateResult;
using Application.Results.Queries.GetResultList;
using Application.Results.Queries.GetResultList.GetResultListByQuantity;
using Application.Results.Queries.GetResultList.GetWholeResultList;

using WebApi.Models;
using WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Asp.Versioning;

namespace Backend.WebApi.Controllers
{
	[ApiVersionNeutral]
	[Produces("application/json")]
	[Route("api/{version:apiVersion}")]
	public class ReactionTestController(IMapper mapper) : BaseController
	{
		private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Creates the result
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /add
        /// {
        ///		reactionTime: 100
        ///		testDate: 2024-01-01\12:00:00+03
		///	}
        /// </remarks>
        /// <param name="createResultDto">CreateResultDto object</param>
        /// <returns>Returns id (guid)</returns>
		/// <response code="201">Success</response>
		/// <response code="401">If the user is unathorized</response>
        [HttpPost("add")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]	
		public async Task<ActionResult<Guid>> AddReactionTestResult
			([FromBody]CreateResultDto createResultDto)
		{
			var command = _mapper.Map<CreateResultCommand>(createResultDto);
			command.UserId = UserId;
			var resultId = await Mediator.Send(command);
			return Ok(resultId);
		}

		/// <summary>
		/// Gets whole list of results
		/// </summary>
		/// <remarks>
		/// GET /get/all
		/// </remarks>
		/// <returns>Returns ResultListVm</returns>
		/// <response code="200">Success</response>
		/// <response code="401">If user is unauthorized</response>
		[HttpGet("get/all")]
        [Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResultListVm>> GetAllReactionTestResults()
		{
			var query = new GetWholeResultListQuery
			{
				UserId = UserId
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

        /// <summary>
        /// Gets the specified quantity of results
        /// </summary>
        /// <remarks>
        /// GET /get/10
        /// </remarks>
        /// <param name="quantity">Quantity of results</param>
        /// <returns>Returns ResultListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If user is unauthorized</response>
        [HttpGet("get/{quantity}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResultListVm>> GetReactionTestResultsByCount(int quantity)
		{
			var query = new GetResultListByQuantityQuery
			{
				UserId = UserId,
				Quantity = quantity
			};

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}
	}
}