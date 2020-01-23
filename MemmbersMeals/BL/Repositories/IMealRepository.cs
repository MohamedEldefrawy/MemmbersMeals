using System;
using System.Collections.Generic;

namespace MemmbersMeals.BL.Repositories
{
    public interface IMealRepository : IRepository<Meal>
    {
        IEnumerable<MemmbersMeal> GetMealsOFMemmberByDate(Memmber selectedMemmber, DateTime dateTime);
        IEnumerable<MemmbersMeal> GetAllMealsOfMemmber(int ID);
    }
}
