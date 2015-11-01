using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Application.Commands;
using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;
using BookKeeping45.Infrastructure.Mediator;

namespace BookKeeping45.Application.Handlers
{
    public class LegoSetHandler : 
        IRequestHandler<CreateNewLegoSetCommand, Unit>,
        IRequestHandler<SaveLegoSetCommand, Unit>,
        IRequestHandler<MarkAsSoldCommand, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public LegoSetHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }

        public Unit Handle(CreateNewLegoSetCommand command)
        {
            var legoSet = new LegoSet(command.Number, command.Name, command.PurchasePrice);

            _legoSetRepository.Add(legoSet);

            return Unit.Value;
        }

        public Unit Handle(MarkAsSoldCommand command)
        {
            var legoSet = _legoSetRepository.GetById(command.Id);

            legoSet.MarkAsSold(command.SellPrice);

            return Unit.Value;
        }

        public Unit Handle(SaveLegoSetCommand command)
        {
            var legoSet = _legoSetRepository.GetById(command.Id);

            if (legoSet == null)
            {
                legoSet = new LegoSet(command.Id, command.Number, command.Name, command.PurchasePrice);
                _legoSetRepository.Add(legoSet);
            }
            else
            {
                legoSet.Update(command.Number, command.Name, command.PurchasePrice);
            }

            return Unit.Value;
        }
    }
}
