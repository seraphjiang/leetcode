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
        public class TupleList<T1, T2> : List<Tuple<T1, T2>>
        {
            public void Add(T1 item, T2 item2)
            {
                Add(new Tuple<T1, T2>(item, item2));
            }
        }
        public class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
        {
            public void Add(T1 item, T2 item2, T3 item3)
            {
                Add(new Tuple<T1, T2, T3>(item, item2, item3));
            }
        }
    }
}
