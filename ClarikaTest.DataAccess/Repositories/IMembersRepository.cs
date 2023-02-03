using ClarikaTest.DataAccess.Domain.Models;

namespace ClarikaTest.DataAccess.Repositories
{
    public interface IMembersRepository
    {
        Task<Members> GetByIdAsync(string email);
        Task<IEnumerable<Members>> GetAllAsync();
        Task AddAsync(Members entity);
        Task UpdateAsync(Members entity);
        Task DeleteAsync(Members entity);

        Task<Members> GetMemberWithTweets(string email); 
    }
}