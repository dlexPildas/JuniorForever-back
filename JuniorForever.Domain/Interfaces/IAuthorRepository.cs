using System.Collections.Generic;
using System.Threading.Tasks;
using JuniorForever.Domain.Models;

namespace JuniorForever.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author[]> GetAllAuthorsAsync();
        Task<Author[]> GetbyNameAsync(string name);
        Task<Author> GetbyIdAsync(int id);
    }
}