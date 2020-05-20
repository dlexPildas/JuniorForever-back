using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Identity;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace JuniorForever.Repository
{
    public class UserRepository : Repository, IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<User[]> GetAllUsers()
        {
            IQueryable<User> query = dataContext.Users;

            return await query.ToArrayAsync();
        }
    }
}
