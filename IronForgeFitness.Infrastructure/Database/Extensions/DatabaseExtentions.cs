using IronForgeFitness.Application.Database;
using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Infrastructure.Database.Contexts;
using IronForgeFitness.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace IronForgeFitness.Infrastructure.Database.Extensions
{
    public static class DatabaseExtentions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddPostgresDatabase(configuration);
            //services.AddMongoDatabase(configuration);
            services.AddInMemoryDatabase();
            services.AddRepositories();
        }

        private static void AddPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("PostgresConnection");
            if (connection != null)
            {
                services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connection));
            }
        }

        private static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("MongoConnection");
            if (connection != null)
            {
                services.AddSingleton(new MongoClient(connection));
            }
        }

        private static void AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(o => o.UseInMemoryDatabase("TestDatabase"));
            services.AddTransient<DbContext, InMemoryContext>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            //DI для репозиториев
            services.AddTransient<IRepository<Employee>, SqlRepository<Employee>>();
            services.AddTransient<IRepository<Customer>, SqlRepository<Customer>>();
            services.AddTransient<IRepository<Item>, SqlRepository<Item>>();
            services.AddTransient<IRepository<Transaction>, SqlRepository<Transaction>>();
            services.AddTransient<IRepository<Subscription>, SqlRepository<Subscription>>();
            services.AddTransient<IRepository<Gym>, SqlRepository<Gym>>();
            services.AddTransient<IRepository<Account>, SqlRepository<Account>>();
            services.AddTransient<IRepository<Training>, SqlRepository<Training>>();
            services.AddTransient<IRepository<Service>, SqlRepository<Service>>();
        }
    }
}
