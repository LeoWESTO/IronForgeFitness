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
            services.AddPostgresDatabase(configuration);
            services.AddMongoDatabase(configuration);
            services.AddRepositories();
        }

        private static void AddPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("PostgreSQLConnection");
            if (connection != null)
            {
                services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connection));
                services.AddTransient<DbContext, PostgresContext>();
            }
        }

        private static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("MongoDBConnection");
            if (connection != null)
            {
                services.AddSingleton(new MongoClient(connection).GetDatabase("iron_forge_fitness"));
            }
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            //DI для репозиториев
            services.AddTransient<IRepository<Gym>, MongoRepository<Gym>>();
            services.AddTransient<IRepository<Item>, MongoRepository<Item>>();
            services.AddTransient<IRepository<Training>, MongoRepository<Training>>();

            services.AddTransient<IRepository<Employee>, SqlRepository<Employee>>();
            services.AddTransient<IRepository<Customer>, SqlRepository<Customer>>();
            services.AddTransient<IRepository<Transaction>, SqlRepository<Transaction>>();
            services.AddTransient<IRepository<Subscription>, SqlRepository<Subscription>>();
            services.AddTransient<IRepository<Account>, SqlRepository<Account>>();
            services.AddTransient<IRepository<Service>, SqlRepository<Service>>();
        }
    }
}
