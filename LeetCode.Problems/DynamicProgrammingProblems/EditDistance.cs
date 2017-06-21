using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1)) return string.IsNullOrEmpty(word2) ? 0 : word2.Length;
            if (string.IsNullOrEmpty(word2)) return word1.Length;

            var dp = new int[word1.Length + 1, word2.Length + 1];

            for (var i = 1; i <= word1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (var i = 1; i <= word2.Length; i++)
            {
                dp[0, i] = i;
            }

            for (var i = 1; i <= word1.Length; ++i)
            {
                for (var j = 1; j <= word2.Length; ++j)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j]));
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                    }
                }
            }

            return dp[word1.Length, word2.Length];
        }
    }
}
