using System.Threading.Tasks;

namespace JuniorForever.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync<T>(T entity) where T : class;
    }
}