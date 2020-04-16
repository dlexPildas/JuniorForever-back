using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using  JuniorForever.Domain.Models;
using  JuniorForever.Repository.Data;

namespace JuniorForever.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("opa, foi!");
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}