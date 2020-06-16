using JuniorForever.Domain.Enum;
using JuniorForever.Domain.Models;
using JuniorForever.Repository;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace JuniorForever.Test.Repository
{
    public class AuthorRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext(new DbContextOptions<DataContext>());


        [Fact]
        public async void CreateAuthorTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);
            Author author = new Author()
            {
                AuthorType = AuthorType.Commentary,
                AvatarUrl = "",
                Bio = "Desconhecida",
                Name = "Teste",
                UserId = 8
            };

            authorRepository.Add(author);
            await authorRepository.SaveChangesAsync();
            var result = await authorRepository.ExistAuthorByName(author.Name);

            Assert.True(result);
        }

        [Fact]
        public async void UpdateAuthorTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var author = await authorRepository.GetAuthorByNameAsync("Teste");
            author.Name = "Teste Atualizado";
            authorRepository.Update(author);
            await authorRepository.SaveChangesAsync();
            var authorUpdated = await authorRepository.ExistAuthorByName("Teste Atualizado");

            Assert.True(authorUpdated);
        }

        [Fact]
        public async void DeleteAuthorTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var author = await authorRepository.GetAuthorByNameAsync("Teste Atualizado");
            authorRepository.Delete(author);
            await authorRepository.SaveChangesAsync();
            var result = await authorRepository.ExistAuthorByName(author.Name);

            Assert.False(result);
        }

        [Fact]
        public async void GetAllAuthorsAsyncTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAllAuthorsAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async void ExistAuthorsByNameAsyncTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorsByNameAsync("Diego");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async void NotExistAuthorsByNameAsyncTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorsByNameAsync("blabla");

            Assert.Empty(result);
        }

        [Fact]
        public async void ExistAuthorByIdAsyncTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorByIdAsync(9);

            Assert.NotNull(result);
        }

        [Fact]
        public async void NotExistAuthorByIdAsyncTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorByIdAsync(9);

            Assert.NotNull(result);
        }

        [Fact]
        public async void ExistAuthorByNameTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.ExistAuthorByName("Diego Fernandes");

            Assert.True(result);
        }

        [Fact]
        public async void NotExistAuthorByNameTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.ExistAuthorByName("Sem nome");

            Assert.False(result);
        }

        [Fact]
        public async void ExistIdAuthorByUserIdTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetIdAuthorByUserId(15);

            Assert.Equal(13, result);
        }

        [Fact]
        public async void NotExistIdAuthorByUserIdTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetIdAuthorByUserId(15);

            Assert.NotEqual(15, result);
        }

        [Fact]
        public async void GetAuthorByNameTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorByNameAsync("Diego Fernandes");

            Assert.NotNull(result);
        }

        [Fact]
        public async void NotGetAuthorByNameTest()
        {
            AuthorRepository authorRepository = new AuthorRepository(_dataContext);

            var result = await authorRepository.GetAuthorByNameAsync("Blabla");

            Assert.Null(result);
        }
    }
}
