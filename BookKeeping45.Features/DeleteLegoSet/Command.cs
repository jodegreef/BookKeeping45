using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Features.DeleteLegoSet
{ 
    public class Command : Request<Unit>
    {
        public Guid Id { get; set; }

        public Command(Guid id)
        {
            Id = id;
        }
    }
}
