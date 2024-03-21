using Microsoft.EntityFrameworkCore;

using Backend.Domain;
using Application.Interfaces;
using Backend.Persistence.EntityTypeConfigurations;

namespace Backend.Persistence
{
    public class ResultsDbContext : DbContext, IResultsDbContext
	{
		public DbSet<Result> Results { get; set; }

		public ResultsDbContext(DbContextOptions<ResultsDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ResultConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
