﻿using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Features.Decorators
{
    public class ValidationHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly List<IValidator<TRequest>> _validators;
        private readonly IRequestHandler<TRequest, TResponse> _innerHandler;

        public ValidationHandler(IRequestHandler<TRequest, TResponse> innerHandler, IEnumerable<IValidator<TRequest>> validators)
        {
            if (innerHandler == null)
                throw new ArgumentNullException("innerHandler");

            _innerHandler = innerHandler;

            _validators = validators.ToList();
        }

        public TResponse Handle(TRequest message)
        {
            var context = new ValidationContext(message);

            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return _innerHandler.Handle(message);
        }
    }

}
