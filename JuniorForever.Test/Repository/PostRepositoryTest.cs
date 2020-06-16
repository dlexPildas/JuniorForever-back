using System;
using JuniorForever.Domain.Models;
using JuniorForever.Repository;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace JuniorForever.Test.Repository
{
    public class PostRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext(new DbContextOptions<DataContext>());

        [Fact]
        public async void CreatePostTest()
        {
            PostRepository postRepository = new PostRepository(_dataContext);
            Post post = new Post()
            {
                AuthorId = 9,
                Content = "Teste",
                Date = DateTime.Now,
                Theme = "Teste",
                Title = "Teste",
            };

            postRepository.Add(post);
            await postRepository.SaveChangesAsync();
            var result = await postRepository.GetPostByTitleAsync("Teste");

            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdatePostTest()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var post = await postRepository.GetPostByTitleAsync("Teste");
            post.Title = "Teste Atualizado";
            postRepository.Update(post);
            await postRepository.SaveChangesAsync();
            var postUpdated = await postRepository.GetPostByTitleAsync("Teste Atualizado");

            Assert.NotNull(postUpdated);
        }

        [Fact]
        public async void DeletePostTest()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var post = await postRepository.GetPostByTitleAsync("Teste Atualizado");
            postRepository.Delete(post);
            await postRepository.SaveChangesAsync();
            var result = await postRepository.GetPostByTitleAsync("Teste Atualizado");

            Assert.Null(result);
        }

        [Fact]
        public async void ExistPosts()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var result = await postRepository.GetAllPostsAsync();

            Assert.True(result.Length > 0);
        }

        [Fact]
        public async void ExistPostById()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var result = await postRepository.GetPostById(19);

            Assert.NotNull(result);
        }

        [Fact]
        public async void NotExistPostById()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var result = await postRepository.GetPostById(0);

            Assert.Null(result);
        }

        [Fact]
        public async void ExistPostByTitleAsyncTest()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var result = await postRepository.GetPostByTitleAsync("Testando mais uma vez");

            Assert.NotNull(result);
        }

        [Fact]
        public async void NotExistPostByTitleAsyncTest()
        {
            PostRepository postRepository = new PostRepository(_dataContext);

            var result = await postRepository.GetPostByTitleAsync("não existe");

            Assert.Null(result);
        }
    }
}