using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

using Backend.Domain;
using Backend.Persistence;

namespace Backend.WebApi.Controllers
{
	[ApiController]
	[Route("api/results")]
	public class ReactionTestController(ResultsDbContext context) : ControllerBase
	{
		private readonly ResultsDbContext _context = context;

		[HttpPost]
		public async Task<ActionResult> AddReactionTestResult([FromBody] JObject jsonData)
		{
			try
			{
				int userId = jsonData["userId"].Value<int>();
				Guid id = Guid.Parse(jsonData["id"].ToString());
				string username = jsonData["username"].ToString();
				int reactionTime = jsonData["reactionTime"].Value<int>();
				DateTime testDate = jsonData["testDate"].Value<DateTime>();

				await _context.Results.AddAsync(
					new Result
					{
						UserId = userId,
						Id = id,
						Username = username,
						ReactionTime = reactionTime,
						TestDate = testDate
					}
				);	

				//await _context.Results.AddAsync(result);
				await _context.SaveChangesAsync();

				return Ok("Test results was added succesfull");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on adding results: {ex.Message}");
			}
		}

		[HttpGet]
		[Route("all")]
		public async Task<ActionResult<List<Result>>> GetAllReactionTestRusults()
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
	}
}