using MemmbersMeals.BL;
using MemmbersMeals.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.DAL
{
    public class UnitOFWork : IUnitOfWork
    {
        private readonly MealsModel mealsModel;
        public IMemmberRepository Memmbers { get; private set; }

        public IMealRepository Meals { get; private set; }

        public UnitOFWork(MealsModel mealsModel)
        {
            this.mealsModel = mealsModel;
            Memmbers = new MemmberRepository(mealsModel);
            Meals = new MealRepository(mealsModel);
        }



        public int Complete()
        {
            return mealsModel.SaveChanges();
        }

        public void Dispose()
        {
            mealsModel.Dispose();
        }
    }
}
