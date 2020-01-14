using MemmbersMeals.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.BL
{
    interface IUnitOfWork : IDisposable
    {
        IMemmberRepository Memmbers { get; }
        IMealRepository Meals { get; }
        int Complete();
    }
}
