using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public string AuthorName { get; set; }

        public string DateTimeCreated { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
