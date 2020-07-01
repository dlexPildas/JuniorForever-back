using System;
using JuniorForever.Api.Controllers;
using JuniorForever.Domain.Models;
using JuniorForever.Repository;
using JuniorForever.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace JuniorForever.Test.Domain
{
    public class PostControllerTest
    {
        private readonly DataContext _dataContext = new DataContext(new DbContextOptions<DataContext>());
        Post post = new Post()
        {
            Title = "test title",
            Content = "test content",
            Date = new DateTime(),
            Theme = "test Tema",
            AuthorId = 9
        };

        [Fact]
        public async void CreatePostTest()
        {
            PostController postController = new PostController(new PostRepository(_dataContext));

            await postController.Post(post);
            var result = await postController.Get(post.Title);

            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdatePostTest()
        {
            PostController postController = new PostController(new PostRepository(_dataContext));

            var postToUpdate = (Post)((OkObjectResult)await postController.Get(post.Title)).Value;
            postToUpdate.Title = "test title updated";
            await postController.Put(postToUpdate);
            var postUpdated = (Post)((OkObjectResult)await postController.Get(postToUpdate.Title)).Value;

            Assert.NotNull(postUpdated);
        }

        [Fact]
        public async void DeletePostTest()
        {
            PostController postController = new PostController(new PostRepository(_dataContext));

            var postToDelete = (Post)((OkObjectResult)await postController.Get("test title updated")).Value;
            await postController.Delete(postToDelete.Id);
            var postDeleted = (Post)((OkObjectResult)await postController.Get("test title updated")).Value;

            Assert.Null(postDeleted);
        }
    }
}
