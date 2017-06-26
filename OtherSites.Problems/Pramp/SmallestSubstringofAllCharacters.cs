using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSites.Problems.Pramp
{
    /// <summary>
    /// Given an array of unique characters arr and a string str, Implement a function getShortestUniqueSubstring that finds the smallest substring of str containing all the characters in arr. Return "" (empty string) if such a substring doesn’t exist.
    ///Come up with an asymptotically optimal solution and analyze the time and space complexities.
    /// https://www.pramp.com/question/wqNo9joKG6IJm67B6z34
    /// </summary>
    public class SmallestSubstringofAllCharacters
    {
        public string GetShortestUniqueSubstring(char[] arr, string str)
        {
            var min = int.MaxValue;
            var start = 0;
            var left = 0;
            var right = 0;
            var total = arr.Length;
            var counts = new int[128];
            foreach (var c in arr)
            {
                counts[c]++;
            }
            while (right < str.Length)
            {
                if (counts[str[right++]]-- > 0) total--;
                while (total == 0)
                {
                    var len = right - left;// not right-left+1, because right has already increase 1
                    if (min > len)
                    {
                        min = len;
                        start = left;
                    }

                    if (counts[str[left++]]++ == 0) total++; //only those belong to arr, count could reach 0
                }
            }

            return min == int.MaxValue ? string.Empty : str.Substring(start, min);
        }

        public string GetShortestUniqueSubstringWrong(char[] arr, string str)
        {
            string res = string.Empty;
            var counts = new int[26];
            var total = 0;
            foreach (var c in arr)
            {
                counts[c - 'a']++;
                total++;
            }

            var start = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                counts[c - 'a']--;

                if (counts[c - 'a'] >= 0)
                {
                    total--;
                    if (total == 0)
                    {
                        var len = i - start + 1;
                        if (len < res.Length || string.IsNullOrEmpty(res)) res = str.Substring(start, i - start + 1);

                        while (counts[start] <= 0)
                        {
                            counts[start]++;

                        }
                    }
                }
            }

            return res;
        }
    }
}