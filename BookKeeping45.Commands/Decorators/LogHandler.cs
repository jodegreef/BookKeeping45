﻿using BookKeeping45.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Commands.Decorators
{
    public class LogHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _innerHandler;
        public LogHandler(IRequestHandler<TRequest, TResponse> innerHandler)
        {
            if (innerHandler == null)
                throw new ArgumentNullException(nameof(innerHandler));
            _innerHandler = innerHandler;
        }

        public TResponse Handle(TRequest request)
        {
            Console.WriteLine("Decoration: Request {0} started", request.GetType().Name);
            var response = _innerHandler.Handle(request);
            Console.WriteLine("Decoration: Request {0} ended", request.GetType().Name);
            return response;
        }
    }
}
