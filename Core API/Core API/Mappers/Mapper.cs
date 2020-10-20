using Core_API.Models;

namespace Core_API.Mappers
{
    public static class Mapper
    {
        public static NewsArticleViewModel NewsArticleToViewModel(this NewsArticle source) =>
        new NewsArticleViewModel
        {
        ID = source.ID,
        ArticleTitle = source.ArticleTitle,
        ArticleContent = source.ArticleContent,
        ArticlePicture = source.ArticlePicture,
        DateTimeCreated = source.DateTimeCreated,
        TimeStampUploaded = source.TimeStampUploaded
        };
    }
}
