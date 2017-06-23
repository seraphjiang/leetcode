using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BacktrackingProblems
{
    public class WordLadderII
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var list = new List<IList<string>>();
            var hs = new HashSet<string>(wordList);
            if (!hs.Contains(endWord)) return list;

            var dict = new Dictionary<string, List<string>>();
            wordList.Add(beginWord);

            foreach (var s in wordList)
            {
                var sb = new StringBuilder(s);
                for (var i = 0; i < s.Length; i++)
                {
                    var o = sb[i];
                    foreach (var c in "abcdefghijklmnopqrstuvwxyz")
                    {
                        sb[i] = c;
                        var key = sb.ToString();
                        if (hs.Contains(key))
                        {
                            if (!dict.ContainsKey(s)) dict[s] = new List<string>();
                            dict[s].Add(key);
                        }
                    }
                    sb[i] = o;
                }
            }

            Dfs(beginWord, endWord, hs, dict, new List<string> { beginWord }, list);

            return list;
        }

        private void Dfs(string begin, string end, HashSet<string> hs, Dictionary<string, List<string>> graph, List<string> path, IList<IList<string>> ret)
        {
            if (begin.Equals(end))
            {
                if (ret.Count == 0 || path.Count == ret[0].Count)
                {
                    ret.Add(new List<string>(path));
                }
                else if (path.Count < ret[0].Count)
                {
                    ret.Clear();
                    ret.Add(new List<string>(path));
                }
                return;
            }

            if (ret.Count > 0 && path.Count > ret[0].Count)
            {
                return;
            }

            var sb = new StringBuilder(begin);

            if (graph.ContainsKey(begin))
            {
                var cols = graph[begin];
                foreach(var node in cols)
                {
                    if (hs.Contains(node))
                    {
                        hs.Remove(node);
                        path.Add(node);
                        Dfs(node, end, hs, graph, path, ret);
                        path.RemoveAt(path.Count - 1);
                        hs.Add(node);
                    }
                }
            }
        }

        public IList<IList<string>> FindLaddersTLE(string beginWord, string endWord, IList<string> wordList)
        {
            var hs = new HashSet<string>(wordList);
            var list = new List<IList<string>>();
            if (!hs.Contains(endWord)) return list;
            DfsTLE(beginWord, endWord, hs, new List<string> { beginWord }, list);
            return list;
        }

        public void DfsTLE(string begin, string end, HashSet<string> hs, List<string> path, IList<IList<string>> ret)
        {
            if (begin.Equals(end))
            {
                if (ret.Count == 0 || path.Count == ret[0].Count)
                {
                    ret.Add(new List<string>(path));
                }
                else if (path.Count < ret[0].Count)
                {
                    //ret = new List<IList<string>>();
                    ret.Clear();
                    ret.Add(new List<string>(path));
                }
                return;
            }

            if (ret.Count > 0 && path.Count > ret[0].Count)
            {
                return;
            }

            var sb = new StringBuilder(begin);
            for (var i = 0; i < begin.Length; ++i)
            {
                var o = sb[i];
                foreach (var c in "abcdefghijklmnopqrstuvwxyz")
                {
                    if (c == sb[i]) continue;
                    sb[i] = c;
                    var key = sb.ToString();
                    if (hs.Contains(key))
                    {
                        hs.Remove(key);
                        path.Add(key);
                        DfsTLE(key, end, hs, path, ret);
                        hs.Add(key);
                        path.RemoveAt(path.Count - 1);
                    }
                    sb[i] = o;
                }
            }
        }
    }
}
