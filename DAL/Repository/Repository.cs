using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext _db;
        internal DbSet<T> dbSet;

        public Repository(DbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
