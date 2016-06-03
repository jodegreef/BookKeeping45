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
    public class DeleteLegoSetCommandHandler : IRequestHandler<DeleteLegoSetCommand, Unit>
    {
        private readonly ILegoSetRepository _legoSetRepository;

        public DeleteLegoSetCommandHandler(ILegoSetRepository legoSetRepository)
        {
            _legoSetRepository = legoSetRepository;
        }


        public Unit Handle(DeleteLegoSetCommand command)
        {
            var legoSet = _legoSetRepository.GetById(command.Id);

            if (legoSet != null)
            {
                _legoSetRepository.Delete(legoSet);
            }

            return Unit.Value;
        }
    }
}
