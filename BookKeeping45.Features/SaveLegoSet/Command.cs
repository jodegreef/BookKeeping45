using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using FluentValidation;

namespace BookKeeping45.Features.SaveLegoSet
{
    public class Command : Request<Unit>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool IsForSale { get; set; }

        public Command(Guid id, int number, string name, decimal purchasePrice, DateTime? purchaseDate, bool isForSale)
        {
            Id = id;
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            IsForSale = isForSale;
        }

        public Command(int number, string name, decimal purchasePrice, DateTime? purchaseDate, bool isForSale)
            : this(Guid.NewGuid(), number, name, purchasePrice, purchaseDate, isForSale)
        {
        }
    }
}
