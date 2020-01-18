using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.DAL.Configrations
{
    public class MealsConfigs : EntityTypeConfiguration<Meal>
    {
        public MealsConfigs()
        {
            Property(e => e.Price)
                .HasPrecision(9, 2);

            HasRequired(m => m.Memmber)
                    .WithMany(a => a.Meals)
                    .HasForeignKey(m => m.MemmberID);

        }

    }
}
