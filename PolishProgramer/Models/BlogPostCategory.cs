using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public class BlogPostCategory
    {
        public BlogPostCategory()
        {
            Posts = new List<BlogPost>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BlogPost> Posts { get; set; }
       
    }
}
