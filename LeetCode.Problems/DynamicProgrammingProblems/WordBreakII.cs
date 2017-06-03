using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class WordBreakII
    {
        Dictionary<int, IList<string>> cache = new Dictionary<int, IList<string>>();
        HashSet<string> dict;
        IList<string> result;
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            dict = new HashSet<string>(wordDict);
            result = new List<string>();

            return Dfs(s, 0);
        }

        public IList<string> Dfs(string s, int start)
        {
            if (cache.ContainsKey(start)) return cache[start];

            var res = new List<string>();
            if(dict.Contains(s.Substring(start))) {
                res.Add(s.Substring(start));
            }
            //if (cache.ContainsKey(start)) return cache[start];
            for (var i = start+1; i < s.Length; ++i)
            {
                var left = s.Substring(start, i - start);
                var right = s.Substring(i);
                if (!dict.Contains(left)) continue;

                var list = new List<string>();
                var rights = Dfs(s, i);
                if (rights.Count > 0)
                {
                    foreach (var r in rights)
                    {
                        res.Add(left + " " + r);
                    }
                }
            }
            cache[start] = res;
            return res;
        }
    }
}
