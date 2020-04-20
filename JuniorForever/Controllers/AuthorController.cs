using System;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using  JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace JuniorForever.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            try
            {
                if(await authorRepository.ExistAuthorByName(author.Name))
                {
                    return Conflict("Autor já cadastrado!");
                }

                authorRepository.Add(author);

                await authorRepository.SaveChangesAsync();
                
                return Ok("Autor cadastradado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e.Message}");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(string filter)
        {
            try
            {
                if (filter == null)
                {
                    var result = await authorRepository.GetAllAuthorsAsync();
                    return Ok(result);
                }

                var result2 = await authorRepository.GetAuthorsByNameAsync(filter);

                return Ok(result2);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await authorRepository.GetAuthorByIdAsync(id);
                
                return Ok(result);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Author author)
        {
            try
            {
                var existAuthor = await authorRepository.GetAuthorByIdAsync(author.Id);

                if (existAuthor == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"O autor  não foi encontrado");
                }

                authorRepository.Update(author);

                await authorRepository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Author author)
        {
            try
            {
                var existAuthor = await authorRepository.GetAuthorByIdAsync(author.Id);

                if (existAuthor == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "O autor não foi encontrado");
                }

                authorRepository.Delete(author);

                await authorRepository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}