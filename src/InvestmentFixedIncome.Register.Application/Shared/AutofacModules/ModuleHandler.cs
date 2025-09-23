using Autofac;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.UseCase;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.UseCase;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.UseCase;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.UseCase;
using InvestmentFixedIncome.Register.Application.Shared.Middlewares;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;

namespace InvestmentFixedIncome.Register.Application.Shared.AutofacModules
{
    public class ModuleHandler : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ExceptionHandler<,>)).As(typeof(IRequestExceptionAction<,>));

            builder.RegisterAssemblyTypes(typeof(FixedIncomeGetAllInput).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(FixedIncomeGetAllUseCase).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(FixedIncomeGetByIdInput).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(FixedIncomeGetByIdUseCase).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(FixedIncomeTaxUpdateInput).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(FixedIncomeTaxUpdateUseCase).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder.RegisterAssemblyTypes(typeof(FixedIncomeStockUpdateInput).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(FixedIncomeStockUpdateUseCase).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
