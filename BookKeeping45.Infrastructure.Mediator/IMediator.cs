using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping45.Infrastructure.Mediator
{
    public interface IMediator
    {
        TResponse Send<TResponse>(IRequest<TResponse> request);
    }
}
