/*using ETicaretAPI.Application.Abstraction;*/
using ETicaretAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        //extension func is static func
        //entegrated from services
        //In order to add the service method in persistance to the ioc container, we must use the extension method.
        public static  void AddPersistenceServices(this IServiceCollection services)
        {


            #region addsingleton
            /*services.AddDbContext<ETicaretUygulamasiDbContext>(
                options => options.UseNpgsql(
                    "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ETicaretDb;"),
                ServiceLifetime.Singleton);

            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();*/
            #endregion
            #region addscoped
            services.AddDbContext<ETicaretUygulamasiDbContext>(
                options => options.UseNpgsql(
                    "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ETicaretDb;"));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            #endregion
        }
    }
}
