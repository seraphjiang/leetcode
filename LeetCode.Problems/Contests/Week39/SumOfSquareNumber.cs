using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week39
{
    public class SumOfSquareNumber
    {
        public static HashSet<int> hs = new HashSet<int>();
        public static int max = 0;
        public static int maxi = 0;
        public bool JudgeSquareSum(int c)
        {

            if (c <= max)
            {
                var list = hs.ToList();
                foreach (var a in list)
                {
                    if (hs.Contains(c - a)) return true;
                }
                return false;
            }

            for (var i = maxi; i * i <= c; i++)
            {
                var sq = i * i;
                hs.Add(sq);

                max = Math.Max(max, sq);
                maxi = i;
                if (hs.Contains(c - sq))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
