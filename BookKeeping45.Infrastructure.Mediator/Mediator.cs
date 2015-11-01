using Autofac;
using System;

namespace BookKeeping45.Infrastructure.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IComponentContext _container;
        public Mediator(IComponentContext container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            _container = container;
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof (IRequestHandler<, >).MakeGenericType(request.GetType(), typeof (TResponse));
            dynamic handler = _container.Resolve(handlerType);
            return handler.Handle((dynamic)request);
        }
    }
}