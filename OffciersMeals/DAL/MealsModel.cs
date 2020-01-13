namespace OffciersMeals
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MealsModel : DbContext
    {
        public MealsModel()
            : base("name=MealsModel")
        {
        }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Offcier> Offciers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Offcier>()
                .Property(e => e.Credit)
                .HasPrecision(9, 2);
        }
    }
}