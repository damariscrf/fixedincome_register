using Autofac;
using InvestmentFixedIncome.Register.Application.Shared.Middlewares;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;

namespace InvestmentFixedIncome.Register.Application.Shared.AutofacModules
{
    public class ModuleMediator : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ExceptionHandler<,>)).As(typeof(IRequestExceptionAction<,>));
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var  componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}
