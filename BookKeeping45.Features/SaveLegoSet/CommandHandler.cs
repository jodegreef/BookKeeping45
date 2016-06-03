using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;
using BookKeeping45.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Features.SaveLegoSet
{
    public class CommandHandler : IRequestHandler<Command, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public CommandHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }

        public Unit Handle(Command command)
        {
            var legoSet = _legoSetRepository.GetById(command.Id);

            if (legoSet == null)
            {
                legoSet = new LegoSet(command.Id, command.Number, command.Name, command.PurchasePrice, command.PurchaseDate, command.IsForSale);
                _legoSetRepository.Add(legoSet);
            }
            else
            {
                legoSet.Update(command.Number, command.Name, command.PurchasePrice, command.PurchaseDate, command.IsForSale);
            }

            return Unit.Value;
        }
    }
}

