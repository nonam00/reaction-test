using Backend.Persistence;

namespace Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly ResultsDbContext Context;

        public TestCommandBase()
        {
            Context = ResultsContextFactory.Create();
        }

        public void Dispose()
        {
            ResultsContextFactory.Destroy(Context);
        }
    }
}
