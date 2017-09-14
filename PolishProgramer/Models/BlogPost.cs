using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public class BlogPost
    {
        
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        
        [Required]
        [MaxLength(20), MinLength(3)]
        public string Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Required]
        public string Text { get; set; }

        public string ImgSrc { get; set; }

        public virtual BlogPostCategory Category { get; set; }
    }
}
