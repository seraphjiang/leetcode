using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week38
{
    public class KInversePairsArray
    {
        public int KInversePairs(int n, int k)
        {
            var dp = new int[n, k + 1];
            dp[0, 0] = 1;
            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j <= k; j++)
                {
                    // dp[i,j] = sum( dp[i-1,j] + dp[i-1, j-1] ... + dp[i-1, j-i))
                    // last num is i;
                    // j-i ... 0;
                    if (j > 0)
                    {
                        dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                        dp[i, j] = j - i > 0 ? (dp[i, j] - dp[i - 1, j - i - 1]) : dp[i, j];
                    }
                    else
                    {
                        for (var m = j; m >= 0 && m >= j - i; m--)
                        {
                            dp[i, j] += dp[i - 1, m];
                        }
                    }

                    dp[i, j] = dp[i, j] > 0 ? dp[i, j] % 1000000007 : (dp[i, j] + 1000000007) % 1000000007;
                }
            }
            return dp[n - 1, k];
        }
        public int KInversePairsTLE(int n, int k)
        {
            var dp = new int[n, k + 1];
            dp[0, 0] = 1;
            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j <= k; j++)
                {
                    // dp[i,j] = sum( dp[i-1,j] + dp[i-1, j-1] ... + dp[i-1, j-i))
                    // last num is i;
                    // j-i ... 0;

                    for (var m = j; m >= 0 && m >= j - i; m--)
                    {
                        dp[i, j] += dp[i - 1, m];
                    }
                    dp[i, j] %= 1000000007;
                }
            }

            return dp[n - 1, k];
        }
        public int KInversePairsWrong(int n, int k)
        {
            var maxPossibleK = 0;
            var l = new List<List<long>>();
            for (var i = 0; i < n; i++)
            {
                maxPossibleK += i;
                l.Add(new List<long>(new long[maxPossibleK + 1]));
            }

            if (k > maxPossibleK) return 0;
            if (k == 0 || k == maxPossibleK) return 1;

            l[0] = new List<long> { 1 };
            l[1] = new List<long> { 1, 1 };

            for (var i = 2; i < n; ++i)
            {
                var count = l[i].Count;
                var mid = count / 2;
                long sum = 0;
                for (var j = 0; j < mid; j++)
                {
                    sum += l[i - 1][j];
                    l[i][j] = sum;
                    l[i][count - 1 - j] = sum;
                }
                if (count % 2 == 1)
                {
                    l[i][mid] = sum + l[i - 1][mid];
                }
            }

            return (int)(l[n - 1][k] % (1000000007));
        }
    }
}
