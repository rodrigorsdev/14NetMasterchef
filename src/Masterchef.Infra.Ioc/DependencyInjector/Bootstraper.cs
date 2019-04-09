using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.Service;
using Masterchef.Domain.Receita.Interface;
using Masterchef.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Masterchef.Infra.Ioc.DependencyInjector
{
    public static class Bootstraper
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static IServiceCollection Services { get; set; }


        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            return RegisterServices(new ServiceCollection(), configuration);
        }

        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;

            //Inject here      
            services.AddScoped<IReceitaService, ReceitaService>();

            services.AddScoped<IReceitaRepository, ReceitaRepository>();
            
            return Services;
        }
    }
}