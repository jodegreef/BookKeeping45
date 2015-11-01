using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Infrastructure.Mediator;
using BookKeeping45.QueryModel;
using BookKeeping45.Queries.Infrastructure;

namespace BookKeeping45.Queries.Handlers
{
    public class InventoryHandler :
        IRequestHandler<GetCompleteInventoryQuery, IReadOnlyList<LegoSet>>
        //,   IRequestHandler<GetInventoryOnSale, Unit>
    {

        private readonly IQueryContext _queryContext;

        public InventoryHandler(IQueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public IReadOnlyList<LegoSet> Handle(GetCompleteInventoryQuery command)
        {
            var result = _queryContext.Set<Domain.Model.LegoSet>()
                .Select(x => new LegoSet
                {
                    Name = x.Name,
                    Number = x.Number,
                    IsSold = x.IsSold,
                    SellPrice = x.SellPrice
                }).ToList();

            return result;


        }

    }
}
