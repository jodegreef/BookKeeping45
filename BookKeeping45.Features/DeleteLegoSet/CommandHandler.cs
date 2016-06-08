using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Features.DeleteLegoSet
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

            if (legoSet != null)
            {
                _legoSetRepository.Delete(legoSet);
            }

            return Unit.Value;
        }
    }
}
