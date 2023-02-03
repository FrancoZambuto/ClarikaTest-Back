using ClarikaTest.DataAccess.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarikaTest.DataAccess.Repositories
{
    public class TweetsRepository : ITweetsRepository
    {
        private readonly ApplicationDBContext _context;

        public TweetsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Tweets> GetByIdAsync(string email)
        {
            return await _context.Tweets.FindAsync(email);
        }

        public async Task<IEnumerable<Tweets>> GetAllAsync()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task AddAsync(Tweets entity)
        {
            await _context.Tweets.AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tweets entity)
        {
            _context.Tweets.Update(entity);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tweets entity)
        {
            _context.Tweets.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}