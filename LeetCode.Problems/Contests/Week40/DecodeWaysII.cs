using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week40
{
    public class DecodeWaysII
    {
        public int NumDecodings(string s)
        {
            long MOD = 1000000007;
            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
            long dp2 = 1;
            long dp1 = s[0] == '*' ? 9 : 1;
            long dp = dp1;

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    if (s[i - 1] == '2') dp = dp1 * 9 + dp2 * 6;
                    else if (s[i - 1] == '1') dp = dp1 * 9 + dp2 * 9;
                    else if (s[i - 1] == '*') dp = dp1 * 9 + dp2 * 15;
                    else if (s[i - 1] > '2' || s[i - 1] == '0') dp = dp1 * 9;
                }
                else if (s[i] == '0')
                {
                    if (s[i - 1] == '2' || s[i - 1] == '1') dp = dp2;
                    else if (s[i - 1] == '*') dp = dp2 * 2;
                    else return 0;
                }
                else
                {   //1..9
                    dp = dp1;

                    if (s[i - 1] == '1') dp = dp1 + dp2;
                    else if (s[i - 1] == '2' && s[i] < '7') dp = dp1 + dp2;
                    else if (s[i - 1] == '*')
                    {
                        if (s[i] < '7') dp = dp1 + dp2 * 2;
                        else dp = dp1 + dp2;
                    }
                }

                dp2 = dp1;
                dp1 = dp % MOD;
            }

            return (int)(dp % MOD);
        }

        public int NumDecodingsWrong(string s)
        {
            long MOD = 1000000007;
            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
            long dp2 = 1;
            long dp1 = s[0] == '*' ? 9 : 1;
            long dp = dp1;

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] == '1' || s[i - 1] == '2') dp = dp1;
                    else if (s[i - 1] == '*') dp = 2 * dp1;
                    else return 0;
                }
                else if (s[i] == '*')
                {
                    if (s[i - 1] == '2') dp = dp1 * 9 + dp2 * 6;
                    else if (s[i - 1] == '1') dp = dp1 * 9 + dp2 * 9;
                    else if (s[i - 1] == '*') dp = dp1 * 9 + dp2 * 15;
                    else if (s[i - 1] > '2' || s[i - 1] == '0') dp = dp1 * 9;

                }
                else
                { // s[i] == 1..9
                    if (s[i - 1] == '1') dp = dp1 + dp2;
                    else if (s[i - 1] == '2')
                    {
                        if (s[i] < '7') dp = dp1 + dp2;
                        else dp = dp1;
                    }
                    else if (s[i - 1] == '*')
                    {
                        if (s[i] < '7') dp = dp1 + dp2;
                        else dp = dp1 + dp2;
                    }
                    else
                    {
                        // s[i-1] == 0 || >'3'
                        dp = dp1;
                    }
                }

                dp2 = dp1;
                dp1 = dp;
            }

            return (int)(dp % MOD);
        }
    }
}
