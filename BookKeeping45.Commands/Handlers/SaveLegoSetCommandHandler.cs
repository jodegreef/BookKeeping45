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
    public class SaveLegoSetCommandHandler : IRequestHandler<SaveLegoSetCommand, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public SaveLegoSetCommandHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }

        public Unit Handle(SaveLegoSetCommand command)
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
