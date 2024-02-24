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
				//int userId = jsonData["userId"].Value<int>();
				//Guid id = Guid.Parse(jsonData["id"].ToString());
				//string username = jsonData["username"].ToString();
				//int reactionTime = jsonData["reactionTime"].Value<int>();
				//DateTime testDate = jsonData["testDate"].Value<DateTime>();

				var newResut = new Result
				{
					UserId = jsonData["userId"].Value<int>(),
					Id = Guid.Parse(jsonData["id"].ToString()),
					Username = jsonData["username"].ToString(),
					ReactionTime = jsonData["reactionTime"].Value<int>(),
					TestDate = jsonData["testDate"].Value<DateTime>()
				};

				await _context.Results.AddAsync(newResut);	

				//await _context.Results.AddAsync(
				//	new Result
				//	{
				//		UserId = userId,
				//		Id = id,
				//		Username = username,
				//		ReactionTime = reactionTime,
				//		TestDate = testDate
				//	}
				//);

				//await _context.Results.AddAsync(result);
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
				int takeCount = int.Parse(count);

				if(takeCount > _context.Results.Count())
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