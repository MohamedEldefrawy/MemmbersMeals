using MemmbersMeals;
using MemmbersMeals.BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffciersMeals.BL.Repository
{

    class MemmberRepository : Repository<Memmber>, IMemmberRepository
    {
        public MemmberRepository(MealsModel model)
            : base(model)
        {

        }

        public IEnumerable<Memmber> GetDebitMemmbers()
        {
            // Do some Work
            throw new NotImplementedException();
        }

        public IEnumerable<Memmber> GetInDebitMemmbers()
        {
            // Do some work
            throw new NotImplementedException();
        }
    }
}
