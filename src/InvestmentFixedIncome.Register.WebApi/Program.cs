using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace InvestmentFixedIncome.Register.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(async (context, builder) =>
                    {
                        builder.AddEnvironmentVariables();

                        var ssmClient = new AmazonSimpleSystemsManagementClient();

                        var parameterResponse = ssmClient.GetParameterAsync(new GetParameterRequest
                        {
                            Name = "/fixedincome/register-db-connection",
                            WithDecryption = true
                        }).GetAwaiter().GetResult(); ;

                        var connectionString = parameterResponse.Parameter.Value;

                        builder.AddInMemoryCollection(new Dictionary<string, string>
                        {
                        { "ConnectionStrings:DefaultConnection", connectionString }
                        });
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