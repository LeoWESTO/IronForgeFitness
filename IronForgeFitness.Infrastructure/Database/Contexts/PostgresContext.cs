using Microsoft.EntityFrameworkCore;

namespace IronForgeFitness.Infrastructure.Database.Contexts
{
    public class PostgresContext : DbContext
    {

        public PostgresContext(DbContextOptions<InMemoryContext> options) : base(options)
        {

        }
    }
}
