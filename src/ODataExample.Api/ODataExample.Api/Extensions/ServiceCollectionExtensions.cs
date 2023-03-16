using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Processors;
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


        public static IServiceCollection AddODataDTOProcessors(this IServiceCollection services)
        {
            return services
                .AddTransient<IODataDTOProcessor<ProductDTO, int>, ProductODataDTOProcessor>()
                ;

        }

        public static IServiceCollection AddODataProcessors(this IServiceCollection services)
        {
            return services
                    .AddTransient<IODataProcessor<Customer, int>, CustomerODataProcessor>()
                ;

        }
    }
}
