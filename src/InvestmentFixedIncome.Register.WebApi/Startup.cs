using Autofac;
using InvestmentFixedIncome.Register.Application.Shared.AutofacModules;
using InvestmentFixedIncome.Register.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;
using System.Diagnostics;

namespace InvestmentFixedIncome.Register.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomSwagger()
                .AddMediatR(typeof(Startup))
                .AddCustomConfiguration(Configuration)
                .AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleHandler());
            builder.RegisterModule(new ModuleMediator());
            builder.RegisterModule(new ModuleRepository());
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddSerilog();
            app.UseSwagger(setup =>
            {
                setup.PreSerializeFilters.Add((document, request) =>
                document.Servers = new List<OpenApiServer>()
                {
                    new OpenApiServer
                    {
                        Url = $"{(Debugger.IsAttached ? "http" : "https")}://{request.Host.Value}"
                    }
                }
                );
            })
            .UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = "swagger";
                setup.SwaggerEndpoint("./v1/swagger.json", name: "Api de Cadastro de Renda Fixa");
            });

            app.UseRouting();
            app.UseDeveloperExceptionPage();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
