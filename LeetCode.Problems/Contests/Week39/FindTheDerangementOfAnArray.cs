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
        public int FindDerangement1(int n)
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

        public int FindDerangement(int n)
        {
            long der = 1;
            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(der);
                der = (i * der + (i % 2 == 0 ? 1 : -1)) % MOD;
            }

            return (int)der;
        }
    }
}
