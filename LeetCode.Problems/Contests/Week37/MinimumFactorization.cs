using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week37
{
    public class MinimumFactorization
    {
        public int SmallestFactorization(int a)
        {
            if (a < 10) return a;
            var ret = new List<int>();
            while (a != 1)
            {
                var before = a;
                for (var i = 9; i >= 1; i--)
                {
                    if (a % i == 0)
                    {
                        a /= i;
                        ret.Add(i);
                        break;
                    }
                }

                if (a == before) return 0;
            }

            if (ret.Count == 0) return 0;

            var sum = 0;
            for (var i = ret.Count - 1; i >= 0; i--)
            {
                if (int.MaxValue / 10 < sum || (int.MaxValue / 10 == sum && int.MaxValue % 10 < ret[i])) return 0;
                sum = sum * 10 + ret[i];
            }

            return sum;
        }
    }
}
