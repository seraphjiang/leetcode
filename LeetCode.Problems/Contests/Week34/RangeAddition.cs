using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week34
{
    public class RangeAddition
    {
        public int MaxCount(int m, int n, int[,] ops)
        {
            if (m == 0 || n == 0) return 0;
            if (ops == null || ops.Length == 0) return m * n;
            var minRow = m;
            var minCol = n;
            var count = ops.GetLength(0);
            for (var i = 0; i < count; ++i)
            {
                minRow = Math.Min(minRow, ops[i, 0]);
                minCol = Math.Min(minCol, ops[i, 1]);
            }

            return (minRow) * (minRow);
        }
    }
}
