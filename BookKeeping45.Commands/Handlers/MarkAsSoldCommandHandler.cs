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
    public class MarkAsSoldCommandHandler : IRequestHandler<MarkAsSoldCommand, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public MarkAsSoldCommandHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }

        public Unit Handle(MarkAsSoldCommand command)
        {
            var legoSet = _legoSetRepository.GetById(command.Id);

            legoSet.MarkAsSold(command.SellPrice);

            return Unit.Value;
        }
    }
}
