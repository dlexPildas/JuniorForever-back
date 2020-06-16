using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorForever.Repository
{
    public class RatingRepository : Repository, IRatingRepository
    {
        private readonly DataContext dataContext;
        public RatingRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Rating[]> GetAllRatings()
        {
            IQueryable<Rating> query = dataContext.Ratings;

            return await query.ToArrayAsync();
        }
    }
}
