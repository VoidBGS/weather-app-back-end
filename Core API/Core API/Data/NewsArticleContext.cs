using Microsoft.EntityFrameworkCore;
using Core_API.Models;

namespace Core_API.Data
{
    public class NewsArticleContext: DbContext
    {
        public NewsArticleContext(DbContextOptions<NewsArticleContext> options)
           : base(options)
        {
        }

        public DbSet<NewsArticle> NewsArticles { get; set; }
    }
}
