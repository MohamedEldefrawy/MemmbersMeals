using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MemmbersMeals.BL.Repositories
{
    public class MemmberRepository : Repository<Memmber>, IMemmberRepository
    {
        private readonly DbContext context;
        public MemmberRepository(DbContext context)
            : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Memmber> GetDebitMemmbers()
        {
            return context.Set<Memmber>().Where(m => m.Credit > 0).ToList();
        }

        public IEnumerable<Memmber> GetInDebitMemmbers()
        {
            return context.Set<Memmber>().Where(m => m.Credit < 0).ToList();
        }

        public IEnumerable<Memmber> GetMemmberbyName(string name)
        {
            return context.Set<Memmber>().Where(m => m.Name.Contains(name)).ToList();
        }

        public void UpdateMemmber(Memmber memmber)
        {
            var result = context.Set<Memmber>().SingleOrDefault(m => m.ID == memmber.ID);
            if (result != null)
            {
                result.Name = memmber.Name;
                result.Credit = memmber.Credit;
                context.Entry(result).State = EntityState.Modified;
            }
        }
    }
}
