using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PostService : IPostService
    {
        public PostDto CreatePost(string title, string content = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            Post post = new Post(title, content);
            post.Create();
            return new PostDto(post);
        }

        public PostDto DeletePost(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id");
            }

            Post post = Post.Find(id);
            post.Delete();
            return new PostDto(post);
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            return Post.All().Select(post => new PostDto
            {
                id = post.id,
                name = post.title,
                description = post.content,
            }).ToList<PostDto>();
        }
    }
}
