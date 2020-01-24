using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MemmbersMeals.PL;


namespace MemmbersMeals.BL.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        private readonly DbContext context;
        public MealRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<MemmbersMeal> GetAllMealsOfMemmber(int ID)
        {
            IEnumerable<Meal> meals = context.Set<Meal>().ToList();
            IEnumerable<Memmber> memmbers = context.Set<Memmber>().ToList();

            var query = from memmber in memmbers
                        join meal in meals
                        on memmber.ID equals meal.MemmberID
                        where (memmber.ID == ID)
                        select new MemmbersMeal()
                        {
                            MealDate = meal.MealsDate.ToString("yyyy/M/d"),
                            MealPrice = meal.Price,
                            MealType = Enum.GetName(typeof(MealsType), meal.MealType)
                        };
            return query;
        }

        public IEnumerable<MemmbersMeal> GetMealsOFMemmberByDate(Memmber selectedMemmber, DateTime dateTime)
        {
            IEnumerable<Meal> meals = context.Set<Meal>().ToList();
            IEnumerable<Memmber> memmbers = context.Set<Memmber>().ToList();

            var query = from memmber in memmbers
                        join meal in meals
                        on memmber.ID equals meal.MemmberID
                        where (memmber.ID == selectedMemmber.ID) && (meal.MealsDate == dateTime)
                        select new MemmbersMeal();

            return query;
        }
    }
}
