using System.Linq.Expressions;

namespace DAL.Repository.IRepository
{
    internal interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filer = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
