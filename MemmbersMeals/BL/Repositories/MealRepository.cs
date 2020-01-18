using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MemmbersMeals.BL.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Meal> GetAllMealsOfMemmber(int ID)
        {
            // DO some work
            throw new NotImplementedException();
        }

        public IEnumerable<Meal> GetMealsOFMemmberByDate(int ID, DateTime dateTime)
        {
            // Do some work
            throw new NotImplementedException();
        }
    }
}
