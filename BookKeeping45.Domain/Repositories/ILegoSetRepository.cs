using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeping45.Domain.Model;

namespace BookKeeping45.Domain.Repositories
{
    public interface ILegoSetRepository
    {
        LegoSet GetByNumber(int id);
        void Add(LegoSet legoSet);
        void Delete(LegoSet legoSet);
    }
}
