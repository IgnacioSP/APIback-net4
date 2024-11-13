using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PostDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public PostDto()
        {
        }

        public PostDto(Post post)
        {
            id = post.id;
            name = post.title;
            description = post.content;
            created_at = post.created_at;
            updated_at = post.updated_at;
        }
    }
}
