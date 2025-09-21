using Autofac;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models;
using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.UseCase;
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
            builder.RegisterAssemblyTypes(typeof(GetAllFixedIncomeInput).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetAllFixedIncomeUseCase).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
