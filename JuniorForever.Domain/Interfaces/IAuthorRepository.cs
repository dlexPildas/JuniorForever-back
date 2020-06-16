using JuniorForever.Domain.Models;
using System.Threading.Tasks;

namespace JuniorForever.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository
    {
        Task<Author[]> GetAllAuthorsAsync();
        Task<Author[]> GetAuthorsByNameAsync(string name);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<bool> ExistAuthorByName(string name);
        Task<int> GetIdAuthorByUserId(int idUser);
        Task<Author> GetAuthorByNameAsync(string name);
    }
}