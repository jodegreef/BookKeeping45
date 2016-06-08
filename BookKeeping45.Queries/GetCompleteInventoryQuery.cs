using BookKeeping45.QueryModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Queries
{
    public class GetCompleteInventoryQuery : IRequest<Inventory>
    {
    }
}
