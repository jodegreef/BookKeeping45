using BookKeeping45.Application.Commands;
using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;
using BookKeeping45.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Commands.Handlers
{
    public class CreateNewLegoSetCommandHandler : IRequestHandler<CreateNewLegoSetCommand, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public CreateNewLegoSetCommandHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }

        public Unit Handle(CreateNewLegoSetCommand command)
        {
            var legoSet = new LegoSet(command.Number, command.Name, command.PurchasePrice, command.PurchaseDate, command.IsForSale);

            _legoSetRepository.Add(legoSet);

            return Unit.Value;
        }


    }
}
