namespace MemmbersMeals
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Meal
    {
        public int ID { get; set; }

        public int MealType { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MealsDate { get; set; }

        public int? MemmberID { get; set; }

        public virtual Memmber Memmber { get; set; }
    }
}
