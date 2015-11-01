using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeping45.Domain.Model;
using BookKeeping45.Domain.Repositories;

namespace BookKeeping45.Infrastructure.EntityFramework
{
    public class LegoSetRepository : ILegoSetRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LegoSetRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(LegoSet legoSet)
        {
            _unitOfWork.Set<LegoSet>().Add(legoSet);
        }

        public void Delete(LegoSet legoSet)
        {
            _unitOfWork.Set<LegoSet>().Remove(legoSet);
        }

        public LegoSet GetByNumber(int number)
        {
            return _unitOfWork.Set<LegoSet>().FirstOrDefault(x => x.Number == number);
        }
    }
}
