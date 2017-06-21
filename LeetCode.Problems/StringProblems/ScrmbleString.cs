using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class ScrmbleString
    {
        public bool IsScramble(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2);
            if (s1.Length != s2.Length) return false;
            if (s1.Equals(s2)) return true;

            if (s1.Length == 1)
            {
                return s1.Equals(s2);
            }

            var count = new int[26];
            foreach (var c in s1)
                count[c - 'a']++;
            foreach (var c in s2)
                count[c - 'a']--;

            foreach (var c in count)
                if (c != 0) return false;

            for (var i = 1; i < s1.Length; i++)
            {
                var left1 = s1.Substring(0, i);
                var right1 = s1.Substring(i, s1.Length - i);
                var left2 = s2.Substring(0, i);
                var right2 = s2.Substring(i, s2.Length - i);

                if (IsScramble(left1, left2) && IsScramble(right1, right2)) return true;
                if (IsScramble(left1, s2.Substring(s2.Length - i)) && IsScramble(right1, s2.Substring(0, s2.Length - i))) return true;

            }

            return false;
        }
    }
}
