using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week39
{
    public class FindTheDerangementOfAnArray
    {
        const long MOD = (long)1e9 + 7;
        public int FindDerangement(int n)
        {
            long a = 0, b = 1, c;
            for (int i = 2; i <= n; i++)
            {
                c = i * (b + a) % MOD;
                a = b;
                b = c;
            }
            return (int)a;
        }
    }
}
