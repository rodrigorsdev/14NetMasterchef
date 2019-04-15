using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Masterchef.Core.Web.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc(
                    settings.MainVersion,
                    new Info
                    {
                        Version = settings.Version,
                        Title = settings.Title,
                        Contact = new Contact
                        {
                            Name = settings.ContactName,
                            Email = settings.ContactEmail,
                            Url = settings.ContactUrl
                        }
                    });

                a.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.ConfigureSwaggerGen(a => { a.OperationFilter<AuthorizationHeaderParameterOperationFilter>(); });
        }

        public static void UseSwaggerUi(this IApplicationBuilder app, string url, string name)
        {
            app.UseSwagger();
            app.UseSwaggerUI(a => a.SwaggerEndpoint(url, name));
        }
    }
}
