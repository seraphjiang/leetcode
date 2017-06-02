using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.SlidingWindow
{
    public class MinimumWindowSubstring
    {
        /// <summary>
        /// https://discuss.leetcode.com/topic/30941/here-is-a-10-line-template-that-can-solve-most-substring-problems
        /// there is template which could solve most of substring problem, worth to read
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            var min = int.MaxValue;
            var start = 0;
            var left = 0;
            var right = 0;
            var map = new int[128];
            var count = t.Length;
            foreach (var c in t)
            {
                map[(int)c]++;
            }
            while (right < s.Length)
            {
                if (map[s[right++]]-- > 0) count--;
                while (count == 0)
                {
                    var d = right - left;
                    if (d < min)
                    {
                        start = left;
                        min = d;
                    }
                    if (map[s[left++]]++ == 0) count++;
                }

            }

            return min == int.MaxValue ? string.Empty : s.Substring(start, min);
        }
    }
}
