using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;

namespace JuniorForever.Repository
{
    class AuthorRepository : Repository, IAuthorRepository
    {

        public AuthorRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<Author[]> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author[]> GetbyNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
