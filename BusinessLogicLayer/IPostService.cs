using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto CreatePost(string title, string content);
        PostDto DeletePost(int id);
    }
}
