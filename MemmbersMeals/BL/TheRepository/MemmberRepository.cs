using System;
using System.Collections.Generic;

namespace MemmbersMeals.BL.Repository
{
    public class MemmberRepository : Repository<Memmber>, IMemmberRepository
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
