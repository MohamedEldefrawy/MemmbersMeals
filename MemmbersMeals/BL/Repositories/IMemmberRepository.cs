using System;
using System.Collections.Generic;

namespace MemmbersMeals.BL.Repositories
{
    public interface IMemmberRepository : IRepository<Memmber>
    {
        IEnumerable<Memmber> GetInDebitMemmbers();
        IEnumerable<Memmber> GetDebitMemmbers();

        IEnumerable<Memmber> GetMemmberbyName(string name);

        void UpdateMemmber(Memmber memmber);
    }
}
