using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;

namespace JuniorForever.Repository
{
    class AuthorRepository : Repository, IAuthorRepository
    {
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
