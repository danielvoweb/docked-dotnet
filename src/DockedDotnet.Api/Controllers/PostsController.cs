using System.Collections.Generic;
using System.Threading.Tasks;
using DockedDotnet.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockedDotnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IRepository<Post> _postsRepository;

        public PostsController(ILogger<PostsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _postsRepository = unitOfWork.PostsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _postsRepository.Get();
        }

        [HttpPost]
        public async Task<Post> Post([FromBody] Post post)
        {
            var createdPost = _postsRepository.Create(post);
            return await createdPost;
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _postsRepository.Remove(x => x.Id == id);
        }
    }
}