using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.GreedyProblems
{
    /// <summary>
    /// Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.
    /// </summary>
    public class RemoveDuplicateLettersProblem
    {
        public string RemoveDuplicateLetters(string s)
        {
            var count = new int[26];
            foreach (var c in s) count[c - 'a']++;
            var pos = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] < s[pos]) pos = i;
                if (--count[s[i] - 'a'] == 0) break;
            }

            return s.Length == 0 ? "" : s[pos] + RemoveDuplicateLetters(s.Substring(pos + 1).Replace("" + s[pos], ""));
        }
    }
}
