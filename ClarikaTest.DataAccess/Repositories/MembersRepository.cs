using ClarikaTest.DataAccess.Domain.Models;
using ClarikaTest.DataAccess.Repositories;
using ClarikaTest.DataAccess;
using Microsoft.EntityFrameworkCore;

    public class MembersRepository : IMembersRepository
    {
        private readonly ApplicationDBContext _context;

        public MembersRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Members> GetByIdAsync(string email)
        {
            return await _context.Members.FindAsync(email);
        }

        public async Task<IEnumerable<Members>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task AddAsync(Members entity)
        {
            await _context.Members.AddAsync(entity);
        }

        public async Task UpdateAsync(Members entity)
        {
            _context.Members.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Members entity)
        {
            _context.Members.Remove(entity);
        await _context.SaveChangesAsync();
    }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Members> GetMemberWithTweets(string email)
        {
            return await _context.Members.Include(m => m.Tweets)
            .FirstOrDefaultAsync(m => m.Email == email);
         }
    }
