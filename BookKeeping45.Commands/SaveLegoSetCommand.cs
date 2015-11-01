﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Application.Commands
{
    public class SaveLegoSetCommand : Request<Unit>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }

        public SaveLegoSetCommand(Guid id, int number, string name, decimal purchasePrice)
        {
            Id = id;
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
        }
    }

    public class SaveLegoSetCommandValidator : AbstractValidator<SaveLegoSetCommand>
    {
        public SaveLegoSetCommandValidator()
        {
            RuleFor(x => x.Number).NotEmpty();
            RuleFor(x => x.Name).Length(1, 255);
        }
    }
}
