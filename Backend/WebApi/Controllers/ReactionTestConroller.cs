using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Domain;
using Backend.Persistence;

using WebApi.Models;

namespace Backend.WebApi.Controllers
{
	[ApiController]
	[Route("api")]
	public class ReactionTestController(ResultsDbContext context) : ControllerBase
	{
		private readonly ResultsDbContext _context = context;

		[HttpPost("add")]
		public async Task<ActionResult> AddReactionTestResult(ResultDto jsonData)
		{
			try
			{
				var newResult = new Result
				{
					Id = Guid.NewGuid(),
					ReactionTime = jsonData.ReactionTime,
					TestDate = jsonData.TestDate
				};

				await _context.Results.AddAsync(newResult);

				await _context.SaveChangesAsync();

				return CreatedAtAction(nameof(GetCertainReactionTestResult), new { id = newResult.Id }, newResult);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on adding results: {ex.Message}");
			}
		}

		[HttpGet("get/certain/{id}")]
		public async Task<ActionResult<Result>> GetCertainReactionTestResult(string id)
		{
			try
			{
				if(!Guid.TryParse(id, out Guid key))
				{
					throw new ArgumentException("Invalid id");
				}

				Result? result = await _context.Results
					.FirstOrDefaultAsync(result => result.Id.Equals(key));

				if(result is null) 
				{
					throw new ArgumentException("Result not found");
				}

				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return StatusCode(400, $"Error on getting result: {ex.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting result: {ex.Message}");
			}
		}
		

		[HttpGet("get/all")]
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


		[HttpGet("get/all/{count}")]
		public async Task<ActionResult<List<Result>>> GetReactionTestResultsByCount(string count)
		{
			try
			{
				if(!int.TryParse(count, out int takeCount) || takeCount < 0)
				{
					throw new ArgumentException("Count parse error");
				}

				if (takeCount > _context.Results.Count())
				{
					takeCount = _context.Results.Count();
				}

				List<Result> recentResults = await _context.Results.OrderByDescending(result => result.TestDate)
																.Take(takeCount)
																.ToListAsync();

				return Ok(recentResults);
			}
			catch (ArgumentException ex)
			{
				return StatusCode(400, $"Error on getting result: {ex.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting results: {ex.Message}");
			}
		}

	}
}