using JuniorForever.Domain.Models;
using System.Threading.Tasks;

namespace JuniorForever.Domain.Interfaces
{
    public interface IPostRepository : IRepository
    {
        Task<Post[]> GetAllPostsAsync();
        Task<Post> GetPostById(int id);
        Task<Post> GetPostByTitleAsync(string title);
    }
}