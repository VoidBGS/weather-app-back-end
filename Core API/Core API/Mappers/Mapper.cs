using Core_API.Models;
using Core_API.ViewModels;

namespace Core_API.Mappers
{
    public static class Mapper
    {
        public static NewsArticleViewModel NewsArticleWithoutAuthorToViewModel(this NewsArticle source) =>
        new NewsArticleViewModel
        {
           ID = source.ID,
           ArticleTitle = source.ArticleTitle,
           ArticleContent = source.ArticleContent,
           ArticlePicture = source.ArticlePicture,
           ArticlePictureCredit = source.ArticlePictureCredit,
           DateTimeCreated = source.DateTimeCreated,
           TimeStampUploaded = source.TimeStampUploaded
        };
        public static NewsArticleViewModel NewsArticleToViewModel(this NewsArticle source, string articleAuthor) =>
        new NewsArticleViewModel
        {
           ID = source.ID,
           AuthorName = articleAuthor,
           ArticleTitle = source.ArticleTitle,
           ArticleContent = source.ArticleContent,
           ArticlePicture = source.ArticlePicture,
           ArticlePictureCredit = source.ArticlePictureCredit,
           DateTimeCreated = source.DateTimeCreated,
           TimeStampUploaded = source.TimeStampUploaded
        };

        public static PictureViewModel PictureToViewModel(this Picture source, string pictureUploader) =>
        new PictureViewModel
        {
            AuthorName = pictureUploader,
            Link = source.Link,
        };
    }
}
