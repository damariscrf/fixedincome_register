using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuider(args).Build().RunAsync();
        }
        public static IHostBuilder CreateHostBuider(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddEnvironmentVariables();
                        //var config = "string de conexao";
                    })
                    .UseStartup<Startup>();
                })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());        
    }
}