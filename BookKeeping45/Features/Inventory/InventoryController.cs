﻿using BookKeeping45.Queries;
using MediatR;
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
        public QueryModel.Inventory Get()
        {
            var inventory = _mediator.Send(new GetCompleteInventoryQuery());
            return inventory;
        }


        public void Post(QueryModel.LegoSet legoSet)
        {
            var result = _mediator.Send(new SaveLegoSet.Command(legoSet.Number, legoSet.Name, legoSet.PurchasePrice, legoSet.PurchaseDate, legoSet.IsForSale));
        }

        public void Put(Guid id, [FromBody] QueryModel.LegoSet legoSet)
        {
            var result = _mediator.Send(new SaveLegoSet.Command(id, legoSet.Number, legoSet.Name, legoSet.PurchasePrice, legoSet.PurchaseDate, legoSet.IsForSale));
        }


        [Route("api/inventory/sold/{id}")]
        public void PutSold(Guid id, [FromBody] QueryModel.LegoSet legoSet)
        {
            var result = _mediator.Send(new MarkAsSold.Command(id, legoSet.SellPrice.GetValueOrDefault()));
        }


        // FYI: this is how you would do a POST instead of a PUT
        //[Route("api/inventory/sold")]
        //public void Post(QueryModel.LegoSet legoSet)
        //{
        //}


        // DELETE: api/Inventory/5
        public void Delete(Guid id)
        {
            var result = _mediator.Send(new DeleteLegoSet.Command(id));
        }
    }
}
