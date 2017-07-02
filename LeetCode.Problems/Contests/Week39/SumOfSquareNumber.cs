using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week39
{
    public class SumOfSquareNumber
    {
        public bool JudgeSquareSum(int c)
        {
            HashSet<long> hs = new HashSet<long>();
            var cl = (long)c;
            for (long i = 0; i * i <= cl; i++)
            {
                long sq = i * i;
                hs.Add(sq);

                if (hs.Contains(c - sq)) return true;
            }

            return false;
        }
    }
}
