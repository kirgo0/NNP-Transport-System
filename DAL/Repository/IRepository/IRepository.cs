using System.Linq.Expressions;

namespace DAL.Repository.IRepository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filer = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        void Remove(T entity);
        void Update(T entity);
        Task SaveAsync();
    }
}
