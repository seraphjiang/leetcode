using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class LongestIncreasingPathInMatrix
    {
        int m;
        int n;
        
        /// <summary>
        /// Brute Force DFS
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[,] matrix)
        {

            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            var cache = new int[m, n];
            var visitied = new bool[m, n];
            var max = 0;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    //max = Math.Max(max, DfsMemoization(matrix, visitied, i, j, 0));
                    //max = Math.Max(max, DfsBruteForce(matrix, visitied, i, j, 0));
                    max = Math.Max(max, DfsCache(matrix, i, j, cache));
                }
            }

            return max;
        }
        public int[,] directions = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        public int DfsBruteForce(int[,] matrix, bool[,] visitied, int x, int y, int length)
        {
            var max = ++length;

            for (var i = 0; i < 4; i++)
            {
                var r = x + directions[i, 0];
                var c = y + directions[i, 1];

                if (r < 0 || r >= m || c < 0 || c >= n || visitied[r, c]) continue;
                if (matrix[r, c] <= matrix[x, y]) continue;

                visitied[r, c] = true;
                var len = DfsBruteForce(matrix, visitied, r, c, length);
                visitied[r, c] = false;
                max = Math.Max(max, len);
            }

            visitied[x, y] = false;
            return max;
        }


        Dictionary<string, int> dict = new Dictionary<string, int>();
        public int DfsMemoization2(int[,] matrix, bool[,] visitied, int x, int y, int length)
        {
            var key = string.Format("{0},{1},{2}", x, y, length);
            if (dict.ContainsKey(key)) return dict[key];
            var max = ++length;

            for (var i = 0; i < 4; i++)
            {
                var r = x + directions[i, 0];
                var c = y + directions[i, 1];

                if (r < 0 || r >= m || c < 0 || c >= n || visitied[r, c]) continue;
                if (matrix[r, c] <= matrix[x, y]) continue;

                visitied[r, c] = true;
                var len = DfsMemoization2(matrix, visitied, r, c, length);
                visitied[r, c] = false;
                max = Math.Max(max, len);
            }
            dict[key] = max;
            visitied[x, y] = false;
            return max;
        }


        public int DfsCache(int[,] matrix,  int x, int y, int[,] cache)
        {
            if (cache[x, y] != 0) return cache[x, y];
            var max = 1;

            for (var i = 0; i < 4; i++)
            {
                var r = x + directions[i, 0];
                var c = y + directions[i, 1];

                if (r < 0 || r >= m || c < 0 || c >= n ) continue;
                if (matrix[r, c] <= matrix[x, y]) continue;
                
                var len = 1 + DfsCache(matrix, r, c, cache);
           
                max = Math.Max(max, len);
            }
           
            cache[x, y] = max;
            return max;
        }
    }
}
