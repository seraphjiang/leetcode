using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class MaximalRectangleProblem
    {
        public int MaximalRectangle(char[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return 0;
            var max = 0;

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var left = new int[n];
            var right = new int[n];
            var height = new int[n];
            for (var i = 0; i < n; ++i)
                right[i] = n;

            for (var i = 0; i < m; i++)
            {
                var l = 0; var r = n;
                for (var j = 0; j < n; ++j)
                {
                    height[j] = matrix[i, j] == '1' ? height[j] + 1 : 0;
                }

                for (var j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == '1')
                    {
                        left[j] = Math.Max(left[j], l); // compute left from left to right
                    }
                    else
                    {
                        l = j + 1;
                        left[j] = 0;// reset
                    }
                }

                for (var j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == '1')
                    {
                        right[j] = Math.Min(right[j], r); // compute left from left to right
                    }
                    else
                    {
                        r = j;
                        right[j] = n;//reset
                    }
                }

                for (var j = 0; j < n; ++j)
                {
                    var area = (right[j] - left[j]) * height[j];
                    max = Math.Max(area, max);
                }
            }
            return max;
        }
    }
}
