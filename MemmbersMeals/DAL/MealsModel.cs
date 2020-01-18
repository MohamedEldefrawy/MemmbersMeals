namespace MemmbersMeals
{
    using MemmbersMeals.DAL.Configrations;
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
            modelBuilder.Configurations.Add(new MealsConfigs());
            modelBuilder.Configurations.Add(new MemmbersConfigs());
        }
    }
}
