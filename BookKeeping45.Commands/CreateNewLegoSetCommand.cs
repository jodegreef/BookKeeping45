using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Application.Commands
{
    public class CreateNewLegoSetCommand : Request<Unit>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }

        public CreateNewLegoSetCommand(int number, string name, decimal purchasePrice)
        {
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
        }
    }

    public class CreateNewLegoSetCommandValidator : AbstractValidator<CreateNewLegoSetCommand>
    {
        public CreateNewLegoSetCommandValidator()
        {
            RuleFor(x => x.Number).NotEmpty();
            RuleFor(x => x.Name).Length(1, 255);
        }
    }
}
