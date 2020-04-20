using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace JuniorForever.Repository
{
    public class PostRepository : Repository, IPostRepository
    {
        private readonly DataContext dataContext;
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Post[]> GetAllPostsAsync()
        {
            IQueryable<Post> query = dataContext.Posts;

            return await query.ToArrayAsync();
        }
    }
}
