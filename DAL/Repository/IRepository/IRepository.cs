using System.Linq.Expressions;

namespace DAL.Repository.IRepository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Remove(T entity);
        void Update(T entity);
        void Save();
    }
}
