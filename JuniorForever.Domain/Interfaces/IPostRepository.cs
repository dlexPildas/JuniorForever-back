using System.Threading.Tasks;
using JuniorForever.Domain.Models;

namespace JuniorForever.Domain.Interfaces
{
    public interface IPostRepository : IRepository
    {
        Task<Post[]> GetAllPostsAsync();
        Task<Post> GetPostById(int id);
    }
}