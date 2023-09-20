using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IronForgeFitness.Infrastructure.Services.Extensions
{
    public static class ServicesExtentions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IGymService, GymService>();
            services.AddTransient<ISubsriptionService, SubscriptionService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITrainingService, TrainingService>();
            services.AddTransient<IServiceService, ServiceService>();
        }
    }
}
