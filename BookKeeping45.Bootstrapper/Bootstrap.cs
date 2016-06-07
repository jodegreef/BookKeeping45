using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Autofac.Core;

using BookKeeping45.Infrastructure.Mediator;
using BookKeeping45.Infrastructure.EntityFramework;
using BookKeeping45.Infrastructure.EntityFramework.Models;
using BookKeeping45.Queries.Infrastructure;
using BookKeeping45.Queries.Handlers;
using BookKeeping45.Features;
using BookKeeping45.Features.Decorators;

namespace BookKeeping45.Bootstrapper
{
    public static class Bootstrap
    {
        public static IContainer Create()
        {
            return Create(null);
        }

        public static IContainer Create(Action<ContainerBuilder> additionalRegistrations)
        {
            IContainer container = null;

            var builder = new ContainerBuilder();

            //Command handlers
            var featuresAssembly = typeof(Features.Features).Assembly;
            builder.RegisterAssemblyTypes(featuresAssembly)
                .As(type => type.GetInterfaces()
                .Where(interfaceType => !interfaceType.Namespace.Contains("Decorators") && interfaceType.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .Select(interfaceType => new KeyedService("requestHandler", interfaceType))); // --> we need a keyed service as the decorated service will become the key-less one

            //query handlers
            builder.RegisterAssemblyTypes(typeof(GetCompleteInventoryQueryHandler).Assembly)
                .Where(interfaceType => !interfaceType.Namespace.Contains("Decorators") && interfaceType.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();
                



            builder.Register(c => new Mediator(c.Resolve<IComponentContext>())).AsImplementedInterfaces();

            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces();
            builder.Register<IQueryContext>(c => new QueryContext(new BookKeepingContext()));

 
            builder.Register<IUnitOfWork>(c => new UnitOfWork(new BookKeepingContext())).SingleInstance();


            builder.RegisterType<LegoSetRepository>().AsImplementedInterfaces();
            //builder.RegisterType<InMemLegoSetRepository>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(featuresAssembly)
               .Where(t => t.Name.EndsWith("Validator"))
               .AsImplementedInterfaces();


            //register the decorator - works
            builder.RegisterGenericDecorator(typeof(ValidationHandler<,>), typeof(IRequestHandler<,>), "requestHandler", "decoratedWithValidation");
            builder.RegisterGenericDecorator(typeof(LogHandler<,>), typeof(IRequestHandler<,>), "decoratedWithValidation", "decoratedWithLog");
            builder.RegisterGenericDecorator(typeof(UnitOfWorkHandler<,>), typeof(IRequestHandler<,>), "decoratedWithLog"); //last decorator must be keyless

            if (additionalRegistrations != null)
                additionalRegistrations.Invoke(builder);


            container = builder.Build();


            return container;
        }

    }
}
