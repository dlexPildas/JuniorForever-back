using JuniorForever.Domain.Models;
using System.Threading.Tasks;

namespace JuniorForever.Domain.Interfaces
{
    public interface IRatingRepository : IRepository
    {
        Task<Rating[]> GetAllRatings();
    }
}