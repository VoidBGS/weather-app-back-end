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
                    AuthorName="Roger Collins",
                    ArticleTitle="Victoria National Park has been livid with...",
                    ArticleContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ArticlePicture="https://i.ibb.co/6sjV0gQ/Mountain-and-waterfall-at-Logan-Pass-at-sunset-in-Glacier-National-Park-Montana.jpg",
                    ArticlePictureCredit="iStock by Getty Images/Guliver Photos",
                    DateTimeCreated=DateTime.Now.ToString("hh:mm | dd-MM-yyyy"),
                    TimeStampUploaded=DateTime.Now,
                },
                new NewsArticle
                {
                    AuthorName="Kristian Lachev",
                    ArticleTitle="The forests South of Georgia have started to gain their fall colors",
                    ArticleContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum..",
                    ArticlePicture="https://i.ibb.co/hC1kxPZ/trees.jpg",
                    ArticlePictureCredit="iStock by Getty Images/Guliver Photos",
                    DateTimeCreated=DateTime.Now.ToString("hh:mm | dd-MM-yyyy"),
                    TimeStampUploaded=DateTime.Now,
                },
                new NewsArticle
                {
                    AuthorName="Colby Connor",
                    ArticleTitle="How to avoid icy roads",
                    ArticleContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum..",
                    ArticlePicture="https://i.ibb.co/6ng9c19/road1.webp",
                    ArticlePictureCredit="iStock by Getty Images/Guliver Photos",
                    DateTimeCreated=DateTime.Now.ToString("hh:mm | dd-MM-yyyy"),
                    TimeStampUploaded=DateTime.Now,
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
