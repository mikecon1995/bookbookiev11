using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string title { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("File Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public string author { get; set; }

        public int price { get; set; }

        public string description { get; set; }
    
        public long ISBN { get; set; }

        public long ISBN13 { get; set; }

        public bool isFeatured { get; set; }

        public bool isNewRelease { get; set; }

    }
}
