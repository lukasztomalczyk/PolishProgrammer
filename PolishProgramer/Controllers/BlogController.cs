using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolishProgramer.Models;
using Microsoft.Extensions.Logging;


namespace PolishProgramer.Controllers
{
    
  
    public class BlogController : Controller
      {
         IPostsRepository postContentDB;
         ILogger _logger;
        
        public ActionResult Index ()
        {
            return PartialView("Blog");
        }

        public BlogController(IPostsRepository _postContentDB, ILoggerFactory loggerFactory)
        {
            postContentDB = _postContentDB;
            _logger = loggerFactory.CreateLogger(nameof(BlogController));
        }

        [Route("Api/Blog/ShowPost/{idPost}")]
        public BlogPost ShowPost (int IdPost)
        {
             var post = postContentDB.GetBlogPost(IdPost);
             return  post;
         }

        [HttpPost("Api/Blog")]
        public IActionResult AddPost([FromBody] BlogPost _blogPost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BlogPost blogPost = postContentDB.CreatPostInBlog(_blogPost);

            return Ok(blogPost);
        }

       

        [HttpGet("Api/Blog")]
        public IEnumerable<BlogPost> ShowPosts()
        {
            var posts = postContentDB.GetPostList();
            return posts ;        
        }

        [Route("Api/Blog/Category/{cat}")]
        public IEnumerable<BlogPost> ShowPostsSorted (int cat)
        {
            var context = postContentDB.GetPostListSort(cat);
            return context;
        }

        [HttpPut("Api/Blog/{_idPost}")]        
        public IActionResult UpdatePostInBlog(int _idPost, [FromBody] BlogPost _blogPost)
        {
            if(_idPost != _blogPost.Id)
            {
                return StatusCode(404, "The Id does not match to BlogPost Id in json");
            }

            BlogPost _postOnBlog = postContentDB.UpdatePost(_blogPost);
            return Ok(_postOnBlog);
        } 

        [HttpDelete("Api/Blog/{_idPost}")]
        public void DeletePostInBlog (int _idPost)
        {
            
  
           
        }


    }
}
