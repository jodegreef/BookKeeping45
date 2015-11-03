using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.QueryModel
{
    public class Inventory
    {
        public IReadOnlyList<LegoSet> LegoSets { get; set; }
        public decimal TotalValue { get;  }
        public decimal TotalValueForSale { get;}
        public decimal TotalValueSold { get; }

        public Inventory(IReadOnlyList<LegoSet> legoSets)
        {
            LegoSets = legoSets;
        }
    }
}
