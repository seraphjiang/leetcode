using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class LongestValidParenthesesProblem
    {
        public int LongestValidParentheses1(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var max = 0;
            var stack = new Stack<int>();
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count > 0 && s[stack.Peek()] == '(')
                    {
                        stack.Pop(); // remove first pair.
                        var pos = -1;
                        if (stack.Count > 0)
                        { // redundant left parenthesis
                            pos = stack.Peek(); // be very caution , don't pop here.
                        }
                        var len = i - pos; // ( i - (pos+1) +1)
                        max = Math.Max(max, len);
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
            }

            return max;
        }

        public int longestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int max = 0;
            int left = -1;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '(') stack.Push(j);
                else
                {
                    if (stack.Count > 0) left = j; // handle ))))) ()
                    else
                    {
                        stack.Pop(); //remove pair
                        if (stack.Count > 0) max = Math.Max(max, j - left); // ))))) ()
                        else max = Math.Max(max, j - stack.Peek()); // ((((( ()
                    }
                }
            }
            return max;
        }

        public int LongestValidParenthesesWrongDP(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var dp = new int[s.Length, s.Length];

            for (var i = s.Length; i > 0; i--)
            {
                for (int r = 0, c = s.Length - i; r < i; r++, c++)
                {
                    if (r == c)
                    {
                        dp[r, c] = 0;
                    }
                    else if (c - r == 1)
                    {
                        dp[r, c] = (s[r] == '(' && s[c] == ')') ? 2 : 0;
                    }
                    else
                    {

                        for (var k = r; k < c; k++)
                        {
                            dp[r, c] = Math.Max(dp[r, c], dp[r, k] + dp[k + 1, c]);
                        }

                        if ((s[r] == '(' && s[c] == ')') && (c - r + 1 == dp[r + 1, c - 1] + 2))
                        {
                            dp[r, c] = c - r + 1;
                        }
                        else
                        {
                            dp[r, c] = Math.Max(dp[r, c], dp[r + 1, c - 1]);
                        }
                    }
                }
            }

            return dp[0, s.Length - 1];
        }
    }
}
