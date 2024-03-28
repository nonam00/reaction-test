using AutoMapper;
using Shouldly;

using Application.Results.Queries.GetResultList;
using Application.Results.Queries.GetResultList.GetResultListByQuantity;
using Backend.Persistence;
using Tests.Common;

namespace Tests.Results.Queries
{
    [Collection("QueryCollection")]
    public class GetResultListByQuantityQueryHandlerTests(
        QueryTestFixture fixture)
    {
        private readonly ResultsDbContext Context = fixture.Context;
        private readonly IMapper Mapper = fixture.Mapper;

        [Fact]
        public async Task GetWholeResultListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetResultListByQuantityQueryHandler(Context, Mapper);
            var quantity = 5;

            // Act
            var result = await handler.Handle(
                new GetResultListByQuantityQuery
                {
                    Quantity = quantity,
                    UserId = ResultsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results!.Count.ShouldBe(2);
        }
    }
}
