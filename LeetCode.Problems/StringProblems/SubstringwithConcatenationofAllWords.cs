using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class SubstringwithConcatenationofAllWords
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var dict = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (!dict.ContainsKey(w)) dict.Add(w, 0);
                dict[w]++;
            }
            var res = new List<int>();
            var wl = words[0].Length;
            var total = wl * words.Length;
            var n = s.Length;
            for (var i = 0; i < wl; ++i) // just iterate all chars is enough for all combination
            {
                var left = i; var count = 0; var seen = new Dictionary<string, int>();
                for (var j = i; j + wl <= n; j += wl)
                {
                    var sub = s.Substring(j, wl);
                    if (dict.ContainsKey(sub))
                    {
                        if (!seen.ContainsKey(sub)) seen[sub] = 0;
                        seen[sub]++;

                        if (seen[sub] <= dict[sub])
                        {
                            count++;
                        }
                        else
                        {
                            // 1 more sub add. need to remove word from head, till sub count match again
                            while (seen[sub] > dict[sub])
                            {
                                var leftword = s.Substring(left, wl);
                                seen[leftword]--; //since we remove word, maintain the new seen count in window
                                if (seen[leftword] < dict[leftword]) count--; // maintain the total seen.
                                left += wl; //pop out left head word
                            }
                        }

                        if (count == words.Length)
                        {
                            res.Add(left);
                            // make it invalid , no need to remove all, just one from left head
                            var leftword = s.Substring(left, wl);
                            seen[leftword]--;
                            count--;
                            left += wl;
                        }
                    }
                    else
                    {
                        left = j + wl;// reset from next word since current work doesn't match
                        count = 0;
                        seen.Clear();//reset the search
                    }
                }
            }

            return res;
        }
        public IList<int> FindSubstringDfsTLE(string s, string[] words)
        {
            var dict = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (!dict.ContainsKey(w)) dict.Add(w, 0);
                dict[w]++;
            }
            var res = new List<int>();
            Dfs(s, dict, 0, res, 0, words[0].Length, words.Length);

            return res;
        }

        public void Dfs(string s, Dictionary<string, int> words, int start, IList<int> res, int count, int len, int total)
        {
            if (start + len > s.Length) return;

            var sub = s.Substring(start, len);
            if (words.ContainsKey(sub) && words[sub] > 0)
            {
                count++;
                if (count == total)
                {
                    res.Add(start - (len * (total - 1)));
                }
                else
                {
                    words[sub]--;
                    Dfs(s, words, start + len, res, count, len, total);
                    words[sub]++;
                }
            }

            Dfs(s, words, start + 1, res, 0, len, total);
        }
    }
}
