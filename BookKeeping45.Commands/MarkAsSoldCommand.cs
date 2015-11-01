using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Application.Commands
{
    public class MarkAsSoldCommand : Request<Unit>
    {
        public Guid Id { get; set; }
        public decimal SellPrice { get; set; }

        public MarkAsSoldCommand(Guid id, decimal sellPrice)
        {
            Id = id;
            SellPrice = sellPrice;
        }
    }
}
