using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Application.Commands
{
    public class DeleteLegoSetCommand : Request<Unit>
    {
        public Guid Id { get; set; }

        public DeleteLegoSetCommand(Guid id)
        {
            Id = id;
        }
    }
}
