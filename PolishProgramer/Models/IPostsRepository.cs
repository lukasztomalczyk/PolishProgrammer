using System.Collections.Generic;

namespace PolishProgramer.Models
{
    public interface IPostsRepository
    {
        List<BlogPost> GetPostList();
        List<BlogPost> GetPostListSort(int sortCategory);
        BlogPost GetBlogPost(int id);
        BlogPost CreatPostInBlog(BlogPost blogPost);
        
        
        BlogPost UpdatePost(BlogPost blog);
    }
}
