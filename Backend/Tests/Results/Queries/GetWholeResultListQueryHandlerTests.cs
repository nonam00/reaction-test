using AutoMapper;
using Shouldly;

using Application.Results.Queries.GetResultList;
using Application.Results.Queries.GetResultList.GetWholeResultList;
using Backend.Persistence;
using Tests.Common;

namespace Tests.Results.Queries
{
    [Collection("QueryCollection")]
    public class GetWholeResultListQueryHandlerTests(
        QueryTestFixture fixture)
    {
        private readonly ResultsDbContext Context = fixture.Context;
        private readonly IMapper Mapper = fixture.Mapper;

        [Fact]
        public async Task GetWholeResultListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetWholeResultListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetWholeResultListQuery
                {
                    UserId = ResultsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results!.Count.ShouldBe(2);
        }
    }
}
