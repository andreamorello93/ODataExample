using ODataExample.Application.Interfaces;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IGenericRepository<Customer, int>, CustomerRepository>()
                .AddTransient<IGenericRepository<Product, int>, ProductRepository>()
                ;
        }
    }
}
