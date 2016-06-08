using BookKeeping45.Infrastructure.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Features.Decorators
{
    public class UnitOfWorkHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _innerHandler;
        private readonly IUnitOfWork _uow;

        public UnitOfWorkHandler(IUnitOfWork uow, IRequestHandler<TRequest, TResponse> innerHandler)
        {
            if (innerHandler == null)
                throw new ArgumentNullException(nameof(innerHandler));
            _uow = uow;
            _innerHandler = innerHandler;
        }

        public TResponse Handle(TRequest request)
        {
            
            var response = _innerHandler.Handle(request);
            _uow.Commit();
            return response;
        }
    }
}
