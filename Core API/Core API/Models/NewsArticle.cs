using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Core_API.Models
{
    public class NewsArticle
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }
        public string ArticleTitle { get; set; }

        public string ArticleContent { get; set; }
        public string ArticlePicture { get; set; }

        public string DateTimeCreated { get; set; }
    }
}
