using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;

namespace CoreAPITests
{
    public class NewsArticleControllerTests: IClassFixture<WebApplicationFactory<Core_API.Startup>>
    {
        private readonly WebApplicationFactory<Core_API.Startup> _factory;
        public NewsArticleControllerTests(WebApplicationFactory<Core_API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Should_Retrieve_NewsArticle()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/NewsArticles");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Should_Not_Retrieve_NewsArticle()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/News");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Get_Should_Retrieve_One_NewsArticle()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/NewsArticles/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_Should_Not_Retrieve_One_NewsArticle()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/NewsArticles/1544545444213");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Post_Should_Succeed_One_NewsArticle()
        {
            var client = _factory.CreateClient();
            string jsonData = @"{  
            'ArticleTitle':'Test',  
            'ArticleContent':'ContentTest',
            'ArticleContent':'PictureTest' 
            }";
            var stringContent = new StringContent(jsonData);

            var response = await client.PostAsync("api/NewsArticles", stringContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task Put_Should_Change_One_NewsArticle()
        {
            var client = _factory.CreateClient();

            string jsonData = @"{  
            'id':'1',
            'ArticleTitle':'Test',  
            'ArticleContent':'ContentTest',
            'ArticleContent':'PictureTest' 
            }";

            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/NewsArticles/1", stringContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
