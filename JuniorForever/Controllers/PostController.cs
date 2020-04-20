using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JuniorForever.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postRepository;
        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await postRepository.GetAllPostsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            try
            {
                postRepository.Add(post);

                await postRepository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}