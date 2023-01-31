using System.Linq.Expressions;

namespace ClarikaTest.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        T Update(T entity);
        Task<T> Get(string email);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Get();
        Task Delete(T entity);
        void SaveChanges();
    }
}
