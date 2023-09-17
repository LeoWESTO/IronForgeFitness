using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace IronForgeFitness.Infrastructure.Database.Contexts
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {

        }
    }
}
