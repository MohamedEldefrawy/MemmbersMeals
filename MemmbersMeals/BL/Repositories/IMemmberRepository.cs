﻿using System.Collections.Generic;

namespace MemmbersMeals.BL.Repositories
{
   public interface IMemmberRepository: IRepository<Memmber>
    {
        IEnumerable<Memmber> GetInDebitMemmbers();
        IEnumerable<Memmber> GetDebitMemmbers();
    }
}