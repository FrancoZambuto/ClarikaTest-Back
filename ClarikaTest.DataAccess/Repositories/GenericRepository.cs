using Microsoft.EntityFrameworkCore;

namespace ClarikaTest.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext _context;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsQueryable().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> Get(string email)
        {
            return await _context.FindAsync<T>(email);
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
