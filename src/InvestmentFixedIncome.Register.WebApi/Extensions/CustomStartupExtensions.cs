using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentFixedIncome.Register.WebApi.Extensions
{
    public static class CustomStartupExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Api de Cadastro de Renda Fixa",
                    Version = "v1",
                    Description = "API para cadastro de investimentos em renda fixa.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Equipe de Desenvolvimento",
                        Email = ""
                    }
                });
            });

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<TimeoutOptions>(configuration.GetSection("ConnectionStrings:TimeOut"));
            services.Configure<ConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
            
            return services;
        }
    }
}
