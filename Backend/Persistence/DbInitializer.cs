namespace Backend.Persistence
{
	public class DbInitializer
	{
		public static void Initialize(ResultsDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
