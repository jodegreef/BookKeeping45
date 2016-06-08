using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using MediatR;

namespace BookKeeping45.Features.MarkAsSold
{ 
    public class Command : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public decimal SellPrice { get; set; }

        public Command(Guid id, decimal sellPrice)
        {
            Id = id;
            SellPrice = sellPrice;
        }
    }
}
