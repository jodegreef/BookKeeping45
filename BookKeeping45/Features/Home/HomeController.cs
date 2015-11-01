using BookKeeping45.Infrastructure.Mediator;
using BookKeeping45.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKeeping45.Features.Home
{
    public class HomeController : Controller
    {
        public IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //HACK: can we do this with routing instead of an explicit action method???
        public ActionResult Index()
        {
            var inventory = _mediator.Send(new GetCompleteInventoryQuery());

            return View(inventory);
        }
    }
}