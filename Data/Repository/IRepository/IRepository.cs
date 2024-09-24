using System.Linq.Expressions;

namespace BulkyWeb.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T FindOne(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
    }
}
