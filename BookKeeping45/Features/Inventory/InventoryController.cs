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

        // GET: api/Inventory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inventory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Inventory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inventory/5
        public void Delete(int id)
        {
        }
    }
}
