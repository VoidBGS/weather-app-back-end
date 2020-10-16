using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace CoreAPITests
{
    public class NewsArticleControllerTests: IClassFixture<WebApplicationFactory<Core_API.Startup>>
    {
        public HttpClient Client { get; }
        public NewsArticleControllerTests(WebApplicationFactory<Core_API.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Retrieve_NewsArticle()
        {
            var response = await Client.GetAsync("api/NewsArticles");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Should_Not_Retrieve_NewsArticle()
        {
            var response = await Client.GetAsync("api/News");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Get_Should_Retrieve_One_NewsArticle()
        {
            var response = await Client.GetAsync("api/NewsArticles/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
