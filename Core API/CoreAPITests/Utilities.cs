using System;
using System.Collections.Generic;
using System.Text;
using Core_API.Data;
using Core_API.Models;

namespace CoreAPITests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(WeatherHovenContext db)
        {
            db.NewsArticles.AddRange(GetSeedingMessages());

            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(WeatherHovenContext db)
        {
            db.NewsArticles.RemoveRange(db.NewsArticles);
            InitializeDbForTests(db);
        }
        public static List<NewsArticle> GetSeedingMessages()
        {
            return new List<NewsArticle>()
            {
             new NewsArticle(){ ID = 1, ArticleTitle = "Amazon rainfire continues past the border.", ArticleContent = "Would you like a jelly baby?Would you like a jelly baby?Would you like a jelly baby?", ArticlePicture = "Picss"},
             new NewsArticle(){ ID = 2, ArticleTitle = "Please dont read this.", ArticleContent = "I said stop reading this...", ArticlePicture = "MonaLisa" },
             new NewsArticle(){ ID = 3, ArticleTitle = "Crazy weather around everywhere.", ArticleContent = "You only adopted the dark. I was born in it. Molded by it. I didn't see the light until I was a man, and by then it was nothing to me but blinding!", ArticlePicture = "Mr. Wayne" }
            };
        }
    }
}
