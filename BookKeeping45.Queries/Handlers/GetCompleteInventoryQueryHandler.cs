﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.QueryModel;
using BookKeeping45.Queries.Infrastructure;
using MediatR;

namespace BookKeeping45.Queries.Handlers
{
    public class GetCompleteInventoryQueryHandler :
        IRequestHandler<GetCompleteInventoryQuery, Inventory>
    {

        private readonly IQueryContext _queryContext;

        public GetCompleteInventoryQueryHandler(IQueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public Inventory Handle(GetCompleteInventoryQuery command)
        {
            var legoSets = _queryContext.Set<Domain.Model.LegoSet>()
                .Select(x => new LegoSet
                {
                    Id = x.Id,
                    Name = x.Name,
                    Number = x.Number,
                    IsSold = x.IsSold,
                    SellPrice = x.SellPrice,
                    PurchasePrice = x.PurchasePrice,
                    PurchaseDate = x.PurchaseDate,
                    IsForSale = x.IsForSale
                }).ToList();

            return new Inventory(legoSets);


        }

    }
}
