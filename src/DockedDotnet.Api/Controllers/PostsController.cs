using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DockedDotnet.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockedDotnet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<Post> Post(Post post)
        {
            var createdPost = _postsRepository.Create(post);
            return await createdPost;
        }
    }
}