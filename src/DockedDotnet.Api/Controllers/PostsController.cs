using System;
using System.Collections.Generic;
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
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(ILogger<PostsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Post Post(Post post)
        {
            throw new NotImplementedException();
        }
    }
}