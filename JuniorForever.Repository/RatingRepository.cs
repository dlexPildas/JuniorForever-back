using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;

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
