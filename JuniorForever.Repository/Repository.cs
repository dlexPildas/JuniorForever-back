﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JuniorForever.Domain.Interfaces;
using JuniorForever.Repository.Data;

namespace JuniorForever.Repository
{
    class Repository : IRepository
    {

        private readonly DataContext dataContext;

        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            dataContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            dataContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            dataContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync<T>(T entity) where T : class
        {
            return (await dataContext.SaveChangesAsync()) > 0;
        }
    }
}
