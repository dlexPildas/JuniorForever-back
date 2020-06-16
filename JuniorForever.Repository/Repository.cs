using JuniorForever.Domain.Interfaces;
using JuniorForever.Repository.Data;
using System.Threading.Tasks;

namespace JuniorForever.Repository
{
    public class Repository : IRepository
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await dataContext.SaveChangesAsync()) > 0;
        }
    }
}
