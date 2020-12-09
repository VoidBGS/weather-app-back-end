using Microsoft.EntityFrameworkCore;
using Core_API.Models;

namespace Core_API.Data
{
    public class WeatherHovenContext: DbContext
    {
        public WeatherHovenContext(DbContextOptions<WeatherHovenContext> options)
           : base(options)
        {
        }

        public DbSet<NewsArticle> NewsArticles { get; set; }

        public DbSet<Picture> Pictures { get; set; }
    }
}
