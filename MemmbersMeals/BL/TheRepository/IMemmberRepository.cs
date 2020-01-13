using System.Collections.Generic;

namespace MemmbersMeals.BL.Repository
{
    interface IMemmberRepository: IRepository<Memmber>
    {
        IEnumerable<Memmber> GetInDebitMemmbers();
        IEnumerable<Memmber> GetDebitMemmbers();
    }
}
