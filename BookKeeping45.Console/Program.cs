using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;

using BookKeeping45.Features;
using BookKeeping45.Bootstrapper;
using BookKeeping45.Queries;
using MediatR;

namespace BookKeeping45.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = Bootstrap.Create();

            var mediator = container.Resolve<IMediator>();

            var result = mediator.Send(new Features.SaveLegoSet.Command(1,"test",5,null,true));

            var inventory = mediator.Send(new GetCompleteInventoryQuery());
            


            System.Console.ReadLine();
        }
    }
}
