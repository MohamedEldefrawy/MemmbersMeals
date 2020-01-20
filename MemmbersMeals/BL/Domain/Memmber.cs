namespace MemmbersMeals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Memmber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Memmber()
        {
            Meals = new HashSet<Meal>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal Credit { get; set; }

        public bool IsDeleted { get; set; } = false;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
