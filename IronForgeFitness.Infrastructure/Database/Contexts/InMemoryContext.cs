using IronForgeFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IronForgeFitness.Infrastructure.Database.Contexts
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {

        }
    }
}
