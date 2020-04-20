using System.Collections.Generic;
using System.Threading.Tasks;
using JuniorForever.Domain.Models;

namespace JuniorForever.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository
    {
        Task<Author[]> GetAllAuthorsAsync();
        Task<Author[]> GetAuthorsByNameAsync(string name);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<bool> ExistAuthorByName(string name);
    }
}