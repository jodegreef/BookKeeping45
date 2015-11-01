using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;

namespace BookKeeping45.Infrastructure.EntityFramework
{
    public class InMemLegoSetRepository : ILegoSetRepository
    {
        private readonly List<LegoSet> _list = new List<LegoSet>();

        public void Add(LegoSet legoSet)
        {
            _list.Add(legoSet);
        }

        public void Delete(LegoSet legoSet)
        {
            _list.Remove(legoSet);
        }

        public LegoSet GetByNumber(int number)
        {
            return _list.FirstOrDefault(x => x.Number == number);
        }
    }
}
