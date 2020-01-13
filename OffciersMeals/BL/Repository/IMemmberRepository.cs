using MemmbersMeals.BL;
using MemmbersMeals.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.BL.Repository
{
    interface IMemmberRepository: IRepository<Memmber>
    {
        IEnumerable<Memmber> GetInDebitMemmbers();
        IEnumerable<Memmber> GetDebitMemmbers();
    }
}
