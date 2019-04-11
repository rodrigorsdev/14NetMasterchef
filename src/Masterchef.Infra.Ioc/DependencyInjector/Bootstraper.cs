using Masterchef.Application.Categoria.Interface;
using Masterchef.Application.Categoria.Service;
using Masterchef.Application.Ingrediente.Interface;
using Masterchef.Application.Ingrediente.Service;
using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.Service;
using Masterchef.Core.Application.Handler;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Categoria.Interface;
using Masterchef.Domain.Ingrediente.Interface;
using Masterchef.Domain.Receita.Interface;
using Masterchef.Infra.Data.Repository;
using Masterchef.Infra.Data.Uow;
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
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IReceitaService, ReceitaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IIngredienteService, IngredienteService>();

            services.AddScoped<IReceitaRepository, ReceitaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();

            return Services;
        }
    }
}