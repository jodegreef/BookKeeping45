using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;

using BookKeeping45.Application.Commands;
using BookKeeping45.Bootstrapper;
using BookKeeping45.Infrastructure.Mediator;
using BookKeeping45.Queries;

namespace BookKeeping45.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = Bootstrap.Create();

            var mediator = container.Resolve<IMediator>();

            var result = mediator.Send(new CreateNewLegoSetCommand(1,"test",5));

            var inventory = mediator.Send(new GetCompleteInventoryQuery());
            


            System.Console.ReadLine();
        }
    }
}
