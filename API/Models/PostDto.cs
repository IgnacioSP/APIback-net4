using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PostDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public PostDto()
        {
        }

        public PostDto(BusinessLogicLayer.PostDto post)
        {
            id = post.id;
            name = post.name;
            description = post.description;
        }
    }
}