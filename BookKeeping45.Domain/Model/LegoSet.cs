using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Domain.Model
{
    public class LegoSet
    {
        public Guid Id { get; set; }
        public virtual int Number { get; private set; }
        public virtual string Name { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal? SellPrice { get; private set; }
        public bool IsSold { get; private set; }

        protected LegoSet()
        {
        }

        public LegoSet(int number, string name, decimal purchasePrice)
        {
            Id = Guid.NewGuid();
            Number = number;
            Name = name;
            PurchasePrice = purchasePrice;
        }


        public void MarkAsSold()
        {
            if (IsSold)
                throw new ApplicationException(string.Format("Set {0} is already sold", Number));

            IsSold = true;
        }
    }
}
