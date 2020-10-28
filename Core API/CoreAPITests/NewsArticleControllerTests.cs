using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using Core_API.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Core_API.Models;
using FluentAssertions;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace CoreAPITests
{
    public class NewsArticleControllerTests : IClassFixture<CustomWebApplicationFactory<Core_API.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Core_API.Startup> _factory;

        public NewsArticleControllerTests(
        CustomWebApplicationFactory<Core_API.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }



        [Fact]
        public async Task Get_Should_Retrieve_NewsArticle()
        {
            var response = await _client.GetAsync("api/NewsArticles");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Should_Not_Retrieve_NewsArticle()
        {
            var response = await _client.GetAsync("api/News");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Get_Should_Retrieve_One_NewsArticle()
        {
            var response = await _client.GetAsync("api/NewsArticles/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Should_Not_Retrieve_One_NewsArticle()
        {
            var response = await _client.GetAsync("api/NewsArticles/1544545444213");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Post_Should_Succeed_NewsArticle()
        {
            var response = await _client.PostAsync("api/NewsArticles", new StringContent(JsonConvert.SerializeObject(new NewsArticle()
            {
                ArticleTitle = "TestTitle",
                ArticleContent = "TestConent",
                ArticlePicture = "TestPicture"
            }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
        [Fact]
        public async Task Put_Should_Succeed_NewsArticle()
        {
            var response = await _client.PutAsync("api/NewsArticles/1", new StringContent(JsonConvert.SerializeObject(new NewsArticle()
            {
                ID = 1,
                ArticleTitle = "TestTitle",
                ArticleContent = "TestConent",
                ArticlePicture = "TestPicture"
            }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Delete_Should_Succeed_NewsArticle()
        {
             var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<NewsArticleContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<Core_API.Startup>>();

                        try
                        {
                            Utilities.ReinitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding " +
                                "the database with test messages. Error: {Message}",
                                ex.Message);
                        }
                    }
                });
            })
       .CreateClient(new WebApplicationFactoryClientOptions
       {
           AllowAutoRedirect = false
       });

            var response = await client.DeleteAsync("api/NewsArticles/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
