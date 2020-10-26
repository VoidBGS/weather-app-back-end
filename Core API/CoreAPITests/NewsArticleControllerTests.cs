using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Core_API.Models;
using FluentAssertions;
using System.Net.Http;

namespace CoreAPITests
{
    public class NewsArticleControllerTests: IntegrationTest
    {
        [Fact]
        public async Task Get_Should_Retrieve_NewsArticle()
        {
            var response = await Client.GetAsync("api/NewsArticles");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Should_Not_Retrieve_NewsArticle()
        {
            var response = await Client.GetAsync("api/News");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Get_Should_Retrieve_One_NewsArticle()
        {
            var response = await Client.GetAsync("api/NewsArticles/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Should_Not_Retrieve_One_NewsArticle()
        {
            var response = await Client.GetAsync("api/NewsArticles/1544545444213");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Post_Should_Succeed_NewsArticle()
        {
            var response = await Client.PostAsync("api/NewsArticles", new StringContent(JsonConvert.SerializeObject(new NewsArticle()
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
            var response = await Client.PutAsync("api/NewsArticles/1", new StringContent(JsonConvert.SerializeObject(new NewsArticle()
            {
                ID = 1,
                ArticleTitle = "TestTitle",
                ArticleContent = "TestConent",
                ArticlePicture = "TestPicture"
            }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task Delete_Should_Succeed_NewsArticle()
        {
            var response = await Client.DeleteAsync("api/NewsArticles/1");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
