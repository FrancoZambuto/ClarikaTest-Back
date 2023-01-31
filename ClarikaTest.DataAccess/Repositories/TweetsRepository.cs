using ClarikaTest.DataAccess.Domain.Models;

namespace ClarikaTest.DataAccess.Repositories
{
    public class TweetsRepository : GenericRepository<Tweets>
    {
        public TweetsRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
