using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Backend.Domain;
using WebApi.Models;

namespace Backend.WebApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class ReactionTestController/*(ResultsDbContext context)*/ : ControllerBase
	{
		//private readonly ResultsDbContext _context = context;
		private readonly ResultService _service;

		public ReactionTestController(ResultService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<Result>>> GetAllReactionTestRusults()
		{
			try
			{
				List<Result> results = await _service.GetAsync();

				return Ok(results);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting results: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Result>> GetReactionTestResult(string id)
		{
			try
			{
				Result result = await _service.GetAsync(id);

				if (result is null) 
				{
					throw new Exception("Not found");
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on getting result: {ex.Message}");
			}
		}


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

				var newResult = new Result
				{
					UserId = userId,
					Id = id,
					Username = username,
					ReactionTime = reactionTime,
					TestDate = testDate
				};

				await _service.CreateAsync(newResult);	

				//await _context.Results.AddAsync(result);
				//await _context.SaveChangesAsync();

				return CreatedAtAction(nameof( GetReactionTestResult), new { id = id }, newResult);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error on adding results: {ex.Message}");
			}
		}

	}
}