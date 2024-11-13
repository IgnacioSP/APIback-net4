using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using BusinessLogicLayer;

namespace API.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public PostsController()
        {
            _postService = new PostService();
        }
        // GET api/Posts
        [HttpGet]
        [Route("GetPosts")]
        public IHttpActionResult GetPosts()
        {
            List<Models.PostDto> posts = _postService.GetAllPosts().Select(post => new Models.PostDto {
                id = post.id,
                name = post.name,
                description = post.description
            }).ToList<Models.PostDto>();

            return Ok(posts);
        }

        // POST api/Posts
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post([FromBody] Models.PostDto dto)
        {
            try
            {
                Models.PostDto post = new Models.PostDto(_postService.CreatePost(dto.name, dto.description));
                return Ok(post);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Posts/5
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Models.PostDto post = new Models.PostDto(_postService.DeletePost(id));
                return Ok(post);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
