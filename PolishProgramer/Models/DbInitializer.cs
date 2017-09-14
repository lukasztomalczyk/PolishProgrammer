using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public class DbInitializer
    {
        public static void Initialize(PostContentDB context)
        {
            context.Database.EnsureCreated();

            if (context.Posts.Any())
            {
                return;   
            }

            var post = new BlogPost[]
            {
            new BlogPost{DateTime=DateTime.Parse("2005-09-01"), CategoryID=1, Author="Jebus", Text="bla bla bla bla bla"},
            new BlogPost{DateTime=DateTime.Parse("2005-09-05"), CategoryID=2, Author="Jebus", Text="da da da da da"},
            new BlogPost{DateTime=DateTime.Parse("2005-09-06"), CategoryID=1, Author="Jebus", Text="Ti Ti Ti Ti"},
            };
            foreach (BlogPost s in post)
            {
                context.Posts.Add(s);
            }

            var cat = new BlogPostCategory[]
            {
                new BlogPostCategory{CategoryName="Programowanie"},
                new BlogPostCategory{CategoryName="Ciekawostki"},
                new BlogPostCategory{CategoryName="Pogaduchy"},
                new BlogPostCategory{CategoryName="Rozwój Osobisty"},
            };

            foreach(BlogPostCategory s in cat)
            {
                context.CategoryPosts.Add(s);
            }
            context.SaveChanges();
        }
    }
}
