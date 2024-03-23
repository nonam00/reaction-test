using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Application.Interfaces;

namespace Backend.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MyPostgresDB");

			services.AddDbContext<ResultsDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			services.AddScoped<IResultsDbContext>(provider =>
				provider.GetService<ResultsDbContext>()!);

			return services;
		}
	}
}