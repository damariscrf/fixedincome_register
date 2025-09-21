using Autofac;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Interface;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Repository;
using InvestmentFixedIncome.Register.Application.Shared.Configuration;
using InvestmentFixedIncome.Register.Application.Shared.Factories;
using InvestmentFixedIncome.Register.Application.Shared.Factories.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentFixedIncome.Register.Application.Shared.AutofacModules
{
    public class ModuleRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbConnectionPostgree>().As<IDbConnectionPostgree>().SingleInstance();

            builder.Register(container =>
            {
                var connectionPostgree = container.Resolve<IDbConnectionPostgree>();
                var options = container.Resolve<IOptions<TimeoutOptions>>();

                return new GetAllFixedIncomeRepository(connectionPostgree,options);
            }).As<IGetAllFixedIncomeRepository>();
        }
    }
}
