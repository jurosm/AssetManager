using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Api.Tests.Integration
{

    public class TestWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {

            return base.CreateHost(builder);
        }
    }

    public class TestBase : IClassFixture<TestWebApplicationFactory<Program>>
    {
        protected readonly TestWebApplicationFactory<Program> _factory;

        public TestBase(TestWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
    }
}
