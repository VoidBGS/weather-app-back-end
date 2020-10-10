using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API.Models;

namespace Core_API.Data
{
    public static class DBInitializer
    {
        public static void Initialize(NewsArticleContext context)
        {
            context.Database.EnsureCreated();

            if (context.NewsArticles.Any())
            {
                return;
            }

            var newsArticles = new NewsArticle[]
            {
                new NewsArticle
                {
                    UserID="1",
                    ArticleTitle="Hurricane on the making",
                    ArticleContent="Hurricane Kris is going to hit Florida on the night of...",
                    ArticlePicture="Picture0",
                    DateTimeCreated="2020-10-10-20:55",
                },
                new NewsArticle
                {
                    UserID="2",
                    ArticleTitle="How to avoid Icy roads",
                    ArticleContent="When the going gets tough the tough get going.",
                    ArticlePicture="Picture1",
                    DateTimeCreated="2020-9-10-20:55",
                },
            };
            foreach (NewsArticle newsArticle in newsArticles)
            {
                context.NewsArticles.Add(newsArticle);
            }
            context.SaveChanges();
        }
    }
}
