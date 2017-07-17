using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week41
{
    /// <summary>
    /// 642. Design Search Autocomplete System My SubmissionsBack to Contest
    /// </summary>
    /// 

    public class AutocompleteSystem
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (var i = 0; i < sentences.Length; i++)
            {
                dict[sentences[i]] = times[i];
            }
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                var cur = sb.ToString();
                if (!dict.ContainsKey(cur)) dict[cur] = 0;
                dict[cur]++;
                sb.Clear();
                return new List<string>();
            }
            else
            {
                sb.Append(c);
                var cur = sb.ToString();


                // O(n^2)
                var res = from e in dict
                          where e.Key.StartsWith(cur)
                          orderby e.Value descending, e.Key
                          select e.Key;
                return res.Take(3).ToList();
            }
        }
    }

    public class AutocompleteSystemOptimize
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        List<KeyValuePair<string, int>> answer;// = new List<KeyValuePair<string, int>>();
        public AutocompleteSystemOptimize(string[] sentences, int[] times)
        {
            for (var i = 0; i < sentences.Length; i++)
            {
                dict[sentences[i]] = times[i];
            }
        }

        public IList<string> Input(char c)
        {
            var res = new List<string>();
            if (c == '#')
            {
                var cur = sb.ToString();
                if (!dict.ContainsKey(cur)) dict[cur] = 0;
                dict[cur]++;
                sb.Clear();
                answer.Clear();
                return res;
            }
            else
            {
                sb.Append(c);
                var cur = sb.ToString();

                if(cur.Length == 1)
                {
                    answer = (from e in dict
                             where e.Key.StartsWith(cur)
                             orderby e.Value descending, e.Key
                             select e).ToList();
                }
                else
                {
                    for(var i = answer.Count - 1; i >= 0; i--)
                    {
                        if (!answer[i].Key.StartsWith(cur))
                        {
                            answer.RemoveAt(i);
                        }
                    }
                }
                
                for(var i=0;i<3 && i < answer.Count; i++)
                {
                    res.Add(answer[i].Key);
                }

                return res;
            }
        }
    }

    public class AutocompleteSystemTLE
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public AutocompleteSystemTLE(string[] sentences, int[] times)
        {
            for (var i = 0; i < sentences.Length; i++)
            {
                dict[sentences[i]] = times[i];
            }
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                var cur = sb.ToString();
                if (!dict.ContainsKey(cur)) dict[cur] = 0;
                dict[cur]++;
                sb.Clear();
                return new List<string>();
            }
            else
            {
                sb.Append(c);
                var cur = sb.ToString();

                var res = from e in dict
                          where e.Key.StartsWith(cur)
                          orderby e.Value descending, e.Key
                          select e.Key;
                return res.Take(3).ToList();
            }
        }
    }
}
