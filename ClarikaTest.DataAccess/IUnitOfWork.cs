using ClarikaTest.DataAccess.Domain.Models;
using ClarikaTest.DataAccess.Repositories;

namespace ClarikaTest.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<Members> MembersRepository { get; }
        IRepository<Tweets> TweetsRepository { get; }

        void SaveChanges();
    }
}
