using ClarikaTest.DataAccess.Domain.Models;

namespace ClarikaTest.DataAccess.Repositories
{
    public interface ITweetsRepository
    {
        Task<Tweets> GetByIdAsync(string email);
        Task<IEnumerable<Tweets>> GetAllAsync();
        Task AddAsync(Tweets entity);
        Task UpdateAsync(Tweets entity);
        Task DeleteAsync(Tweets entity);
    }
}
