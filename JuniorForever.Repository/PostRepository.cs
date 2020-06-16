using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorForever.Repository
{
    public class PostRepository : Repository, IPostRepository
    {
        private readonly DataContext _dataContext;
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Post[]> GetAllPostsAsync()
        {
            IQueryable<Post> query = _dataContext.Posts
                .Include(x => x.Author)
                .Include(x => x.Ratings)
                .ThenInclude(x => x.Author);

            return await query.ToArrayAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            IQueryable<Post> query = _dataContext.Posts
                .Include(x => x.Author);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> GetPostByTitleAsync(string title)
        {
            IQueryable<Post> query = _dataContext.Posts;

            return await query.FirstOrDefaultAsync(x => x.Title == title);
        }
    }
}
