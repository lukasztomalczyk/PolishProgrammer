using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public class PostsRepository : IPostsRepository
    {
        private readonly PostContentDB _context;
        private readonly ILogger _logger;

        public PostsRepository(PostContentDB context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("PostsRepository");
        }

        public List<BlogPost> GetPostList()
        {
            return _context.Posts.OrderBy(c => c.DateTime).ToList();
        }

        public List<BlogPost> GetPostListSort(int _sortCategory)
        {
     
            return _context.Posts.Where(c=>c.CategoryID == _sortCategory)
                                       .OrderBy(c => c.DateTime).ToList();
        }

        public BlogPost GetBlogPost (int  _idPost)
        {
            return _context.Posts.SingleOrDefault(c => c.Id == _idPost);
        }

        public BlogPost CreatPostInBlog (BlogPost blogPost)
        {
            _context.Posts.Add(blogPost);
            _context.SaveChanges();
            return blogPost;
        }

   

        public bool CheckPostExists(int _idPost)
        {
            bool _check = _context.Posts.Any(a => a.Id == _idPost);

            if (_check == false )
            {
                throw new InvalidOperationException("Post not found");
            }

            return true;
        }

        public BlogPost UpdatePost (BlogPost _blogPost)
        {
            if (CheckPostExists(_blogPost.Id)==true)
            {
                BlogPost _post = _context.Posts.First(b => b.Id == _blogPost.Id);

                if (_post != null)
                {
                    _post.Author = _blogPost.Author;
                    _post.CategoryID = _blogPost.CategoryID;
                    _post.Text = _blogPost.Text;
                    _post.DateTime = _blogPost.DateTime;

                    _context.SaveChanges();

                    return _post;
                }
                else
                {
                    throw new InvalidOperationException("Empty rekord");
                }
            }
            return _blogPost;
              
            
               
        }                             
    }
}