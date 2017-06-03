using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class RegularExpressionMatching
    {
        public bool IsMatch(string s, string p)
        {
            return Dfs(s, p, 0, 0);
        }
        public bool IsMatchBackTracking(string s, string p)
        {
            return Dfs(s, p, 0, 0);
        }

        /// <summary>
        /// even it is an AC solution, there lots of redundant check code.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool Dfs(string s, string p, int l, int r)
        {
            if (l < s.Length && r < p.Length)
            {
                if (s[l] == p[r] || p[r] == '.')
                {
                    if (r + 1 < p.Length && p[r + 1] == '*')
                    {
                        while (l < s.Length && (s[l] == p[r] || p[r] == '.'))
                        {
                            if (Dfs(s, p, l, r + 2)) return true;
                            l++;
                        }
                        return (Dfs(s, p, l, r + 2));
                    }
                    else
                    {
                        return Dfs(s, p, l + 1, r + 1);
                    }
                }
                else if (p[r] == '*' && (r - 1 >= 0) && p[r - 1] == s[l])
                {
                    while (l < s.Length && p[r - 1] == s[l])
                    {
                        if (Dfs(s, p, l, r + 1)) return true; // cover "aaa", "a*a"
                        l++;
                    }
                    return Dfs(s, p, l, r + 1);
                }
                else if (p[r] == '*' && (r - 1 >= 0) && p[r - 1] == '.') // match .*
                {
                    for (var i = l; i <= s.Length; i++)
                    {
                        if (Dfs(s, p, i, r + 1)) return true;
                    }
                    return false;
                }
                else if (p[r] == '*')
                {
                    return Dfs(s, p, l, r + 1);
                }
                else if (r + 1 < p.Length && p[r + 1] == '*')
                {
                    return Dfs(s, p, l, r + 2);
                }
            }

            while (r < p.Length)
            {
                if (p[r] == '*') r++;
                else if (r + 1 < p.Length && p[r + 1] == '*')
                {
                    r++;
                }
                else
                {
                    break;
                }
            }

            return l == s.Length && r == p.Length;
        }
    }
}
