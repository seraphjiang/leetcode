using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    [Problem(Company = "Google", Level = Level.Median)]
    public class RangeAddition
    {
        public int[] GetModifiedArray(int length, int[,] updates)
        {
            var res = new int[length];

            for (var i = 0; i < updates.GetLength(0); i++)
            {
                res[updates[i, 0]] += updates[i, 2];
                if (updates[i, 1] != res.Length - 1) res[updates[i, 1] + 1] -= updates[i, 2];
            }

            for (var i = 0; i < res.Length; i++)
            {
                res[i] += i == 0 ? 0 : res[i - 1];
            }

            return res;
        }

        public int[] GetModifiedArrayTLE(int length, int[,] updates)
        {
            var res = new int[length];
            for (var i = 0; i < updates.GetLength(0); i++)
            {
                for (var j = updates[i, 0]; j <= updates[i, 1]; j++)
                {
                    res[j] += updates[i, 2];
                }
            }

            return res;
        }
    }
}
