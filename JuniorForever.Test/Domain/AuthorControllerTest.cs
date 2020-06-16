using JuniorForever.Api.Controllers;
using JuniorForever.Domain.Enum;
using JuniorForever.Domain.Models;
using JuniorForever.Repository;
using JuniorForever.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace JuniorForever.Test.Domain
{
    public class AuthorControllerTest
    {
        private readonly DataContext _dataContext = new DataContext(new DbContextOptions<DataContext>());
        private readonly Author _author = new Author()
        {
            AuthorType = AuthorType.Commentary,
            AvatarUrl = "",
            Bio = "Desconhecida",
            Name = "TesteController",
            UserId = 8
        };

        [Fact]
        public async void CreateAuthorTest()
        {
            AuthorController authorController = new AuthorController(new AuthorRepository(_dataContext));
            
            await authorController.Post(_author);
            var result = (OkObjectResult) await authorController.GetAuthorByName("TesteController");

            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void UpdateAuthorTest()
        {
            AuthorController authorController = new AuthorController(new AuthorRepository(_dataContext));

            var author = (Author) ((OkObjectResult) await authorController.GetAuthorByName("TesteController")).Value;
            author.Name = "Daniel";
            await authorController.Put(author);
            var result = (OkObjectResult) await authorController.Get("Daniel");

            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void DeleteAuthorTest()
        {
            AuthorController authorController = new AuthorController(new AuthorRepository(_dataContext));
            
            var author = (Author) ((OkObjectResult)await authorController.GetAuthorByName("Daniel")).Value;
            await authorController.Delete(author);
            var result = (Author)((OkObjectResult)await authorController.GetAuthorByName("Daniel")).Value;

            Assert.Null(result);
        }

        [Fact]
        public async void ExistAuthorIdTest()
        {
            AuthorController authorController = new AuthorController(new AuthorRepository(_dataContext));

            var result = (OkObjectResult) await authorController.Get(9);

            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void NotExistAuthorIdTest()
        {
            AuthorController authorController = new AuthorController(new AuthorRepository(_dataContext));

            var result = (OkObjectResult) await authorController.Get(1);

            Assert.Null(result.Value);
        }
    }
}
