using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.DAL.Configrations
{
    public class MemmbersConfigs : EntityTypeConfiguration<Memmber>
    {
        public MemmbersConfigs()
        {
            Property(m => m.IsDeleted)
                .IsRequired()
                .HasColumnType("bit");

            Property(m => m.Credit)
                .HasPrecision(9, 2);
        }
    }
}
