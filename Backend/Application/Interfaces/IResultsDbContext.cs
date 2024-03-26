using Microsoft.EntityFrameworkCore;

using Backend.Domain;

namespace Application.Interfaces
{
	public interface IResultsDbContext
	{
		DbSet<Result> Results { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
