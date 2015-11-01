using BookKeeping45.Application.Commands;
using BookKeeping45.Infrastructure.Mediator;
using BookKeeping45.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookKeeping45.Features.Inventory
{
    public class InventoryController : ApiController
    {
        public IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Inventory
        public IEnumerable<QueryModel.LegoSet> Get()
        {
            var inventory = _mediator.Send(new GetCompleteInventoryQuery());
            return inventory;
        }



        public void Put(Guid id, [FromBody] QueryModel.LegoSet value)
        {
            var result = _mediator.Send(new SaveLegoSetCommand(id, value.Number, value.Name, value.PurchasePrice));
        }


        [Route("api/inventory/sold/{id}")]
        public void PutSold(Guid id, [FromBody] QueryModel.LegoSet value)
        {
            var result = _mediator.Send(new MarkAsSoldCommand(id, value.SellPrice.GetValueOrDefault()));
        }


        // FYI: this is how you would do a POST instead of a PUT
        //[Route("api/inventory/sold")]
        //public void Post(QueryModel.LegoSet legoSet)
        //{
        //}


        // DELETE: api/Inventory/5
        public void Delete(int id)
        {
        }
    }
}
