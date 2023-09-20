using IronForgeFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IronForgeFitness.Infrastructure.Database.Contexts
{
    public class PostgresContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }
    }
}
