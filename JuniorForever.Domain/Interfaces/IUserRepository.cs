using System.Threading.Tasks;
using JuniorForever.Domain.Identity;

namespace JuniorForever.Domain.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<User[]> GetAllUsers();
    }
}
