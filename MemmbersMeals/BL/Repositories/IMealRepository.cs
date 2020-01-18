using System;
using System.Collections.Generic;

namespace MemmbersMeals.BL.Repositories
{
    public interface IMealRepository : IRepository<Meal>
    {
        IEnumerable<Meal> GetMealsOFMemmberByDate(int ID, DateTime dateTime);
        IEnumerable<Meal> GetAllMealsOfMemmber(int ID);
    }
}
