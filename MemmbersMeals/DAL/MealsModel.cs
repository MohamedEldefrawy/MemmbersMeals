namespace MemmbersMeals
{
    using System.Data.Entity;

    public partial class MealsModel : DbContext
    {
        public MealsModel()
            : base("name=MealsModel")
        {
        }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Memmber> Memmbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Meal>()
                .HasRequired(m => m.Memmber)
                .WithMany(a => a.Meals)
                .HasForeignKey(m => m.MemmberID);

            modelBuilder.Entity<Memmber>()
                .Property(e => e.Credit)
                .HasPrecision(9, 2);
        }
    }
}
