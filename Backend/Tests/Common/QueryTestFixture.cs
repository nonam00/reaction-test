using AutoMapper;

using Application.Interfaces;
using Application.Common.Mappings;
using Backend.Persistence;

namespace Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ResultsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ResultsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IResultsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();  
        }

        public void Dispose()
        {
            ResultsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
