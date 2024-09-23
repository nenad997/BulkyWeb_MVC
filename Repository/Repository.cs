using BulkyWeb.Data;
using BulkyWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace BulkyWeb.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public T FindOne(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().FirstOrDefault(filter)!;
        }

        public List<T> GetAll()
        {
            return db.Set<T>()!.ToList();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            this.Save();
        }

        public void Remove(T entity)
        {
            db.Set<T>().Remove(entity);
            this.Save();
        }

        public void Save()
        {
            this.db.SaveChanges();
        }
    }
}
