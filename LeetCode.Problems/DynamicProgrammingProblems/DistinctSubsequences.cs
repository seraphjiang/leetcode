using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class DistinctSubsequences
    {
        public int NumDistinct(string s, string t)
        {
            if (t.Length > s.Length) return 0;
            var dp = new int[t.Length + 1, s.Length + 1];

            for (var i = 0; i < s.Length; ++i) dp[0, i] = 1;

            for (var i = 0; i < t.Length; ++i)
            {
                for (var j = 0; j < s.Length; ++j)
                {
                    dp[i + 1, j + 1] = dp[i + 1, j] + (t[i] == s[j] ? dp[i, j] : 0);
                }
            }

            return dp[t.Length, s.Length];
        }
    }
}
