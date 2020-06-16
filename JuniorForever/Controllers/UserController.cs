using AutoMapper;
using JuniorForever.Api.Dtos;
using JuniorForever.Domain.Identity;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JuniorForever.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IAuthorRepository authorRepository;

        public UserController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository userRepository, IAuthorRepository authorRepository)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserAuthorDto userAuthorDto)
        {
            try
            {
                var user = mapper.Map<User>(userAuthorDto.UserDto);

                var result = await userManager.CreateAsync(user, userAuthorDto.UserDto.Password);

                if (result.Succeeded)
                {
                    var author = mapper.Map<Author>(userAuthorDto.AuthorDto);
                    author.User = user;

                    authorRepository.Add(author);

                    await authorRepository.SaveChangesAsync();

                    return StatusCode(StatusCodes.Status201Created, "Usuário criado com sucesso!");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar usuário");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userLoginDto.UserName);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Usuário não foi encontrado");
                }

                var authorId = await authorRepository.GetIdAuthorByUserId(user.Id);

                var result = await signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await userManager.Users
                        .FirstOrDefaultAsync(x => x.NormalizedUserName == userLoginDto.UserName.ToUpper());

                    var userToReturn = mapper.Map<UserLoginDto>(appUser);

                    return Ok(new
                    {
                        token = GenerateJWToken(appUser).Result,
                        user = userToReturn,
                        authorId = authorId
                    });
                }

                return Unauthorized("Usuário não encontrado!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}