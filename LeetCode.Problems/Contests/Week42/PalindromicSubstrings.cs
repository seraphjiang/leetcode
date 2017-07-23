using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week42
{
    public class PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            var total = 0;
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    if (IsPalindromic(s, i, j)) total++;
                }
            }

            return total;
        }

        public bool IsPalindromic(string s, int i, int j)
        {

            while (i < j)
            {
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }

            return true;
        }
    }
}
