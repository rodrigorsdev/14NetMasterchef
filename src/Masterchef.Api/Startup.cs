using Masterchef.Core.Authentication.Jwt;
using Masterchef.Core.Web.Compression;
using Masterchef.Core.Web.Swagger;
using Masterchef.Infra.Data.Context;
using Masterchef.Infra.Ioc.DependencyInjector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Masterchef.Api
{
    public class Startup
    {
        private const string SwaggerEndpoint = "/swagger/v1/swagger.json";
        private const string SwaggerName = "Contracts API v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Bootstraper.RegisterServices(services, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwagger(new SwaggerSettings
            {
                MainVersion = "v1",
                Version = "v1.0.0.0",
                Title = "Masterchef",
                ContactEmail = "rodrigo.soliveira2322@gmail.com",
                ContactName = "Rodrigo Oliveira",
                ContactUrl = "http://fiap.com.br"
            });

            services.AddCompression(CompressionLevel.Optimal);

            services.AddDbContext<MasterchefContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                        a => a.MigrationsAssembly("Masterchef.Web")));

            services.AddJwtAuthentication("r2development@123");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseSwaggerUi(SwaggerEndpoint, SwaggerName);

            app.UseResponseCompression();

            app.UseAuthentication();
        }
    }
}
