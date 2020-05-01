using System.Threading.Tasks;
using JuniorForever.Domain.Models;

namespace JuniorForever.Domain.Interfaces
{
    public interface IRatingRepository : IRepository
    {
        Task<Rating[]> GetAllRatings();
    }
}