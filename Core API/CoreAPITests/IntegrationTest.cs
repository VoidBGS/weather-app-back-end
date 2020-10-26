using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Core_API.Data;
using System.Threading.Tasks;
using System.Net;

namespace CoreAPITests
{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;
        protected IntegrationTest()
        {
            var _factory = new WebApplicationFactory<Core_API.Startup>()
                 .WithWebHostBuilder(builder =>
                 {
                     builder.ConfigureServices(services =>
                     {
                         services.RemoveAll(typeof(NewsArticleContext));
                         services.AddDbContext<NewsArticleContext>(options =>
                         {
                             options.UseInMemoryDatabase("TestingDatabase");
                         });
                     });
                 });
            Client = _factory.CreateClient();
        }
    }
}
