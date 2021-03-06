﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.QueryModel
{
    public class LegoSet
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsSold { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? SellPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool IsForSale { get; set; }
    }
}
