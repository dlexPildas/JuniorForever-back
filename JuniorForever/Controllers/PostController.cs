﻿using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JuniorForever.Api.Controllers
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
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var posts = await postRepository.GetAllPostsAsync();

                return Ok(posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var post = await postRepository.GetPostById(id);

                return Ok(post);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{title}/title")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string title)
        {
            try
            {
                var post = await postRepository.GetPostByTitleAsync(title);

                return Ok(post);
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

        [HttpPut]
        public async Task<IActionResult> Put(Post post)
        {
            try
            {
                var existPost = await postRepository.GetPostById(post.Id);

                if (existPost != null)
                {
                    postRepository.Update(post);

                    await postRepository.SaveChangesAsync();

                    return Ok("Post atualizado com sucesso");
                }

                return NotFound("O post não foi encontrado");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existPost = await postRepository.GetPostById(id);

                if (existPost != null)
                {
                    postRepository.Delete(existPost);

                    await postRepository.SaveChangesAsync();

                    return Ok("Post deletado com sucesso!");
                }

                return NotFound("O post não foi encontrado");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}