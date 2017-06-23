using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class DungeonGame
    {
        /// <summary>
        /// http://leetcodesolution.blogspot.com/2015/01/leetcode-dungeon-game.html
        /// 
        ///  this is different to robot matrix.
        ///  1. not ask for shortest path
        ///  2. init from bottom - right
        /// </summary>
        /// <param name="dungeon"></param>
        /// <returns></returns>
        public int CalculateMinimumHP(int[,] dungeon)
        {
            var m = dungeon.GetLength(0);
            var n = dungeon.GetLength(1);
            var dp = new int[m, n];

            for (var i = m - 1; i >= 0; i--)
            {
                for (var j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 && j == n - 1)
                    {
                        dp[i, j] = Math.Max(1, 1 - dungeon[i, j]);
                    }
                    else if (i == m - 1)
                    {
                        dp[i, j] = Math.Max(1, dp[i,j+1] - dungeon[i, j]);
                    }
                    else if (j == n - 1)
                    {
                        dp[i, j] = Math.Max(1, dp[i + 1, j] - dungeon[i, j]);
                    }
                    else
                    {
                        dp[i, j] = Math.Max(1, Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i, j]);
                    }
                }
            }

            return dp[0, 0];
        }
        public int CalculateMinimumHPWrong(int[,] dungeon)
        {
            var m = dungeon.GetLength(0);
            var n = dungeon.GetLength(1);
            var dp = new int[m, n];
            var remain = new int[m, n];
            remain[0, 0] = 1 + dungeon[0, 0];
            dp[0, 0] = dungeon[0, 0] > 0 ? 1 : (-dungeon[0, 0] + 1);
            remain[0, 0] = Math.Max(1, remain[0, 0]);
            for (var i = 1; i < m; i++)
            {
                remain[i, 0] = remain[i - 1, 0] + dungeon[i, 0];
                dp[i, 0] = remain[i, 0] > 0 ? dp[i - 1, 0] : (dp[i - 1, 0] - remain[i, 0] + 1);
                remain[i, 0] = Math.Max(1, remain[i, 0]);
            }

            for (var i = 1; i < n; i++)
            {
                remain[0, i] = remain[0, i - 1] + dungeon[0, i];
                dp[0, i] = remain[0, i] > 0 ? dp[0, i - 1] : (dp[0, i - 1] - remain[0, i] + 1);
                remain[0, i] = Math.Max(1, remain[0, i]);
            }

            for (var i = 1; i < m; ++i)
            {
                for (var j = 1; j < n; ++j)
                {
                    var remainFromUp = remain[i - 1, j] + dungeon[i, j];
                    var remainFromLeft = remain[i, j - 1] + dungeon[i, j];
                    var dpFromUP = remainFromUp > 0 ? dp[i - 1, j] : (dp[i - 1, j] - remainFromUp + 1);
                    var dpFromLeft = remainFromLeft > 0 ? dp[i, j - 1] : (dp[i, j - 1] - remainFromLeft + 1);
                    dp[i, j] = dpFromUP < dpFromLeft ? dpFromUP : dpFromLeft;
                    remain[i, j] = Math.Max(1, dpFromUP < dpFromLeft ? remainFromUp : remainFromLeft);
                }
            }

            return dp[m - 1, n - 1];
        }

        public int CalculateShortestPath(int[,] dungeon)
        {
            var m = dungeon.GetLength(0);
            var n = dungeon.GetLength(1);
            var dp = new int[m, n];

            for (var i = 0; i < m; i++)
            {
                dp[i, 0] = dungeon[i, 0];
            }

            for (var i = 0; i < n; i++)
            {
                dp[0, i] = dungeon[0, i];
            }

            for (var i = 1; i < m; ++i)
            {
                for (var j = 1; j < n; ++j)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]) + dungeon[i, j];
                }
            }

            return dp[m - 1, n - 1]; // this is min HP , this is shortest path.
        }
    }
}
