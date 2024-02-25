using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

using Backend.Domain;
using Backend.Persistence;

namespace Backend.WebApi.Controllers
{
	[ApiController]
	[Route("api")]
	public class ReactionTestController(ResultsDbContext context) : ControllerBase
	{
		private readonly ResultsDbContext _context = context;

		[HttpPost("add")]
		public async Task<ActionResult> AddReactionTestResult([FromBody] JObject jsonData)
		{
			try
			{
				bool guidParseCheck = Guid.TryParse(jsonData["id"].ToString(), out Guid id);
				if (!guidParseCheck)
				{
					throw new ArgumentException("Guid parse error");
				}

				var newResult = new Result
				{
					Id = id,
					ReactionTime = jsonData["reactionTime"].Value<int>(),
					TestDate = jsonData["testDate"].Value<DateTime>()
				};

				await _context.Results.AddAsync(newResult);

				await _context.SaveChangesAsync();

				return Ok("Test results was added successful");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on adding results: {ex.Message}");
			}
		}

		[HttpGet("get")]
		public async Task<ActionResult<List<Result>>> GetAllReactionTestResults()
		{
			try
			{
				List<Result> results = await _context.Results.ToListAsync();

				return Ok(results);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting results: {ex.Message}");
			}
		}

		[HttpGet("get/{count}")]
		public async Task<ActionResult<List<Result>>> GetReactionTestResultsByCount(string count)
		{
			try
			{
				bool takeCountCheck = int.TryParse(count, out int takeCount);

				if(!takeCountCheck)
				{
					throw new ArgumentException("Count parse error");
				}

				if (takeCount > _context.Results.Count())
				{
					takeCount = _context.Results.Count();
				}

				List<Result> results = await _context.Results.ToListAsync();

				var recentResults = results.TakeLast(takeCount)
										.OrderByDescending(result => result.TestDate);

				return Ok(recentResults);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting results: {ex.Message}");
			}
		}

	}
}