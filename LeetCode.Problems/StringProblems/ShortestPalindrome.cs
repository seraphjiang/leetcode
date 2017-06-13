using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class ShortestPalindromeProblem
    {
        public string ShortestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var index = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (IsPalindrome(s, i))
                {
                    index = i;
                    break;
                }
            }

            if (index == s.Length - 1) return s;

            var sb = new StringBuilder();

            for (var i = s.Length - 1; i > index; i--)
            {
                sb.Append(s[i]);
            }

            sb.Append(s);

            return sb.ToString();
        }

        public bool IsPalindrome(string s, int end)
        {
            var start = 0;
            while (start < end)
            {
                if (s[start] != s[end]) return false;
                start++;
                end--;
            }

            return true;
        }
    }
}
