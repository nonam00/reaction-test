using Microsoft.EntityFrameworkCore;
using Xunit;

using Application.Results.Commands.CreateResult;
using Tests.Common;

namespace Tests.Results.Commands
{
    public class CreateResultCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateResultCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateResultCommandHandler(Context);
            int reactionTime = 200;
            DateTime testDate = DateTime.Now;

            // Act
            var resultId = await handler.Handle(
                new CreateResultCommand
                {
                    UserId = ResultsContextFactory.UserAId,
                    ReactionTime = reactionTime,
                    TestDate = testDate
                },
                CancellationToken.None);

            Assert.NotNull(
                await Context.Results.SingleOrDefaultAsync(result =>
                    result.Id == resultId &&
                    result.ReactionTime == reactionTime &&
                    result.TestDate == testDate));
        }
    }
}
