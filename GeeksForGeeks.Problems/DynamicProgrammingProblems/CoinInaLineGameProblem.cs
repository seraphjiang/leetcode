using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Problems.DynamicProgrammingProblems
{
    /// <summary>
    /// Problem statement: Consider a row of n coins of values v1 . . . vn, 
    /// where n is even. We play a game against an opponent by alternating turns. 
    /// In each turn, a player selects either the first or last coin from the row, 
    /// removes it from the row permanently, and receives the value of the coin. 
    /// Determine the maximum possible amount of money we can definitely win if we move first.
    /// Note: The opponent is as clever as the user.
    /// 
    /// http://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/
    /// http://algorithms.tutorialhorizon.com/dynamic-programming-coin-in-a-line-game-problem/
    /// 
    /// Asked in: Amazon
    /// </summary>
    public class CoinInaLineGameProblem
    {
        public int OptimalStrategyOfGame(int[] array)
        {
            var n = array.Length;
            var dp = new int[n, n];
            // Fill table using above recursive formula. Note that the table
            // is filled in diagonal fashion (similar to http://goo.gl/PQqoS),
            // from diagonal elements to table[0][n-1] which is the result.
            
            // j equals to i means diagonal line, 
            // j always large or equals than i, means, vaild result is right up half triangle of square. 
            for (var gap = 0; gap < n; gap++)
            {
                for (int i = 0, j = gap; j < n; i++, j++)
                {
                    var x = i + 2 <= j ? dp[i + 2, j] : 0;
                    var y = i + 1 <= j - 1 ? dp[i + 1, j - 1] : 0;
                    var z = i <= j - 2 ? dp[i, j - 2] : 0;

                    dp[i, j] = Math.Max(array[i] + Math.Min(x, y), array[j] + Math.Min(y, z));
                }
            }

            return dp[0, n - 1];
        }
    }
}
