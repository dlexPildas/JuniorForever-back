using JuniorForever.Domain.Identity;
using System.Threading.Tasks;

namespace JuniorForever.Domain.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<User[]> GetAllUsers();
    }
}
