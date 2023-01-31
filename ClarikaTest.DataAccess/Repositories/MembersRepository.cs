using ClarikaTest.DataAccess.Domain.Models;

namespace ClarikaTest.DataAccess.Repositories
{
    public class MembersRepository : GenericRepository<Members>
    {
        public MembersRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
