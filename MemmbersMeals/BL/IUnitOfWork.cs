using MemmbersMeals.BL.Repositories;
using System;

namespace MemmbersMeals.BL
{
    interface IUnitOfWork : IDisposable
    {
        IMemmberRepository Memmbers { get; }
        IMealRepository Meals { get; }
        int Complete();
    }
}
