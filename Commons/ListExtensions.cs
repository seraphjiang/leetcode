using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class ListExtensions
    {
        public static bool SetEquals<T>(this IList<T> x, IList<T> y)
        {
            return x.Count() == y.Count()
                && !x.Except(y).Any()
                && !y.Except(x).Any();
        }
    }
}
