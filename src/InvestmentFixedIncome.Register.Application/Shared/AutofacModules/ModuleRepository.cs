using Autofac;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Repository;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Repository;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Interface;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Repository;
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

                return new FixedIncomeGetAllRepository(connectionPostgree,options);
            }).As<IFixedIncomeGetAllRepository>();

            builder.Register(container =>
            {
                var connectionPostgree = container.Resolve<IDbConnectionPostgree>();
                var options = container.Resolve<IOptions<TimeoutOptions>>();

                return new FixedIncomeTaxUpdateRepository(connectionPostgree, options);
            }).As<IFixedIncomeTaxUpdateRepository>();

            builder.Register(container =>
            {
                var connectionPostgree = container.Resolve<IDbConnectionPostgree>();
                var options = container.Resolve<IOptions<TimeoutOptions>>();

                return new FixedIncomeStockUpdateRepository(connectionPostgree, options);
            }).As<IFixedIncomeStockUpdateRepository>();
        }
    }
}
