using ClarikaTest.DataAccess.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarikaTest.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Members> Members { get; set; }
        public DbSet<Tweets> Tweets { get; set; }
    }
}
