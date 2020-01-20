using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.PL.Helpers
{
    public static class ParseDecimalString
    {
        public static decimal Parse(string value)
        {
            decimal result;

            if (decimal.TryParse(value, out result))
                return result;
            else
                return 0;
        }
    }
}
