using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API.Models
{
    public class NewsArticleViewModel
    {
        public int ID { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleContent { get; set; }

        public string ArticlePicture { get; set; }

        public string ArticlePictureCredit { get; set; }

        public string DateTimeCreated { get; set; }

        public DateTime TimeStampUploaded { get; set; }
    }
}
