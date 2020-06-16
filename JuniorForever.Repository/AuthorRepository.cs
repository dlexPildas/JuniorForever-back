using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorForever.Repository
{
    public class AuthorRepository : Repository, IAuthorRepository
    {

        private readonly DataContext dataContext;

        public AuthorRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Author[]> GetAllAuthorsAsync()
        {
            IQueryable<Author> query = dataContext.Authors
                .OrderBy(x => x.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Author[]> GetAuthorsByNameAsync(string name)
        {
            IQueryable<Author> query = dataContext.Authors
                .Where(x => x.Name.Contains(name));

            var result = await query.ToArrayAsync();

            return result;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            IQueryable<Author> query = dataContext.Authors;

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistAuthorByName(string name)
        {
            IQueryable<Author> query = dataContext.Authors;

            return await query.AnyAsync(x => x.Name == name);
        }

        public async Task<int> GetIdAuthorByUserId(int idUser)
        {
            var query = (from a in dataContext.Authors
                         where a.UserId == idUser
                         select a.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            IQueryable<Author> query = dataContext.Authors;

            return await query.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
