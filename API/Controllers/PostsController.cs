using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            this._context = context;
        }
        
        
        /// <summary>
        /// GET api/posts
        /// </summary>
        /// <returns> A list of posts</returns>
        [HttpGet(Name = "GetPosts")]

        public ActionResult<List<Post>> Get()
        {
            return this._context.Posts.ToList();
        }

        /// <summary>
        /// Get api/post/ [id]
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>A single post</return>
        [HttpGet("{id}", Name ="GetById")]
        public ActionResult<Post> GetById(Guid id)
        {
            var post = this._context.Posts.Find(id);
            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}