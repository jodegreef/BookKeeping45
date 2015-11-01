﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Domain.Model
{
    public class LegoSet
    {
        public Guid Id { get; private set; }
        public virtual int Number { get; private set; }
        public virtual string Name { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal? SellPrice { get; private set; }
        public bool IsSold { get; private set; }

        protected LegoSet()
        {
        }

        public LegoSet(Guid id, int number, string name, decimal purchasePrice)
        {
            Id = id;
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
        }


        public LegoSet(int number, string name, decimal purchasePrice) : this(Guid.NewGuid(), number, name, purchasePrice)
        {
        }


        public void MarkAsSold(decimal sellPrice)
        {
            if (IsSold)
                throw new ApplicationException(string.Format("Set {0} is already sold", Number));

            IsSold = true;
            SellPrice = SellPrice;
        }

        public void Update(int number, string name, decimal purchasePrice)
        {
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
        }
    }
}
