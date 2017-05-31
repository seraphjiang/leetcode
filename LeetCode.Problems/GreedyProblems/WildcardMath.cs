using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.GreedyProblems
{
    public class WildcardMath
    {
        public bool IsMatch(string s, string p)
        {
            var l = 0; var r = 0;
            var lastStart = -1;
            var lastS = 0;
            while (l < s.Length)
            {
                if (r < p.Length && (s[l] == p[r] || p[r] == '?'))
                {
                    l++; r++; continue;
                }
                else if (r < p.Length && p[r] == '*')
                {
                    lastStart = r; r++;
                    lastS = l; continue;
                }
                else if (lastStart >= 0)
                {
                    l = ++lastS;
                    r = lastStart + 1;  continue;
                }

                return false;
            }
            //l already reach its end.let's check if r reach its end.

            while (r < p.Length && p[r] == '*')
            {
                r++;
            }

            return r == p.Length;
        }

        public bool IsMatchRecursiveTLE(string s, string p)
        {
            return IsMatch(s, p, 0, 0);
        }

        public bool IsMatch(string s, string p, int l, int r)
        {
            if (l < s.Length && r < p.Length)
            {
                if (s[l] == p[r] || '?' == p[r])
                {
                    return IsMatch(s, p, ++l, ++r);
                }
                else if (p[r] == '*')
                {
                    while (r < p.Length && p[r] == '*')
                    {
                        r++;
                    }

                    for (var i = l; i <= s.Length; i++)
                    {
                        if (IsMatch(s, p, i, r))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            else
            {
                while (r < p.Length && p[r] == '*')
                {
                    r++;
                }
                if (s.Length == l && p.Length == r)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
