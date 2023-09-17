using IronForgeFitness.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IronForgeFitness.Infrastructure.Services.Extensions
{
    public static class ServicesExtentions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<CustomerService>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<ItemService>();
            services.AddTransient<TransactionService>();
        }
    }
}
