using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Features.SaveLegoSet
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Number).NotEmpty();
            RuleFor(x => x.Name).Length(1, 255);
        }
    }
}
