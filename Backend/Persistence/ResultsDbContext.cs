using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Backend.Domain;
using Backend.Persistence.EntityTypeConfigurations;

namespace Backend.Persistence
{
    public class ResultsDbContext : DbContext
	{
		public DbSet<Result> Results { get; set; }

		public ResultsDbContext(DbContextOptions<ResultsDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ResultConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
