using Microsoft.EntityFrameworkCore;

using Backend.Domain;
using Backend.Persistence;

namespace Tests.Common
{
    public class ResultsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static ResultsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ResultsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ResultsDbContext(options);
            context.Database.EnsureCreated();
            context.Results.AddRange(
                new Result
                {
                    Id = Guid.Parse("37EC7258-2BB0-4474-B1A6-347A4B7DB256"),
                    UserId = UserAId,
                    ReactionTime = 200,
                    TestDate = DateTime.Now,
                },
                new Result
                {
                    Id = Guid.Parse("0975D9D8-B4E0-4330-9BB7-9C81EE24FCCC"),
                    UserId = UserBId,
                    TestDate = DateTime.Now,
                    ReactionTime = 300
                },
                new Result
                {
                    Id = Guid.Parse("8E928BAD-B759-41C5-B589-A51C63C2D251"),
                    UserId = UserAId,
                    TestDate = DateTime.Now,
                    ReactionTime = 100
                },
                new Result
                {
                    Id = Guid.Parse("E21EA10B-17AE-488C-8752-042C1470C4E3"),
                    UserId = UserBId,
                    TestDate = DateTime.Now,
                    ReactionTime = 150
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ResultsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
