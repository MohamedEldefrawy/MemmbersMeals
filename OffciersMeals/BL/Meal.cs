namespace OffciersMeals
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Meal
    {
        public int ID { get; set; }

        public int MealType { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime MealsDate { get; set; }

        public int? OffcierID { get; set; }

        public virtual Offcier Offcier { get; set; }
    }
}
