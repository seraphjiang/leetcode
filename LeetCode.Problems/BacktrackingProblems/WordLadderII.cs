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
            var result = new List<IList<string>>();
            if (string.IsNullOrEmpty(beginWord) || string.IsNullOrEmpty(endWord) || wordList == null || !wordList.Any())
                return result;
            var neighbours = new Dictionary<string, List<string>>();
            var set = new HashSet<string>(wordList);
            var distance = new Dictionary<string, int>();
            distance[beginWord] = 0;
            set.Add(beginWord);
            Bfs(beginWord, endWord, neighbours, distance, set);
            Dfs(beginWord, endWord, neighbours, distance, result, new List<string>());
            return result;
        }

        private void Bfs(string begin, string end, Dictionary<string, List<string>> neighbours, Dictionary<string, int> distance, HashSet<string> set)
        {
            var queue = new Queue<string>();
            var isEnd = false;
            queue.Enqueue(begin);
            while (queue.Any() && !isEnd)
            {
                var t = new Queue<string>();
                while (queue.Any())
                {
                    var node = queue.Dequeue();
                    var newNeighbours = GetNeighbours(node, set);
                    foreach (var newWord in newNeighbours)
                    {
                        if (!neighbours.ContainsKey(node))
                        {
                            neighbours[node] = new List<string>();
                        }
                        neighbours[node].Add(newWord);
                        if (!distance.ContainsKey(newWord))
                        {
                            distance[newWord] = distance[node] + 1;
                            if (newWord == end)
                            {
                                isEnd = true;
                                break;
                            }
                            else
                            {
                                t.Enqueue(newWord);
                            }
                        }
                    }
                }
                queue = t;
            }
        }

        private void Dfs(string start, string end, Dictionary<string, List<string>> neighbours, Dictionary<string, int> distance, IList<IList<string>> result, IList<string> temp)
        {
            temp.Add(start);
            if (start == end)
            {
                result.Add(new List<string>(temp));
            }
            else
            {
                if (neighbours.ContainsKey(start))
                {
                    foreach (var newWord in neighbours[start])
                    {
                        if (distance[newWord] == distance[start] + 1)
                        {
                            Dfs(newWord, end, neighbours, distance, result, temp);
                        }
                    }
                }

            }

            temp.RemoveAt(temp.Count - 1);
        }


        private IList<string> GetNeighbours(string word, HashSet<string> set)
        {
            var result = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                var tempWord = word.ToCharArray();
                var cTemp = tempWord[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c != cTemp)
                    {
                        tempWord[i] = c;
                        var newString = new string(tempWord);
                        if (set.Contains(newString))
                        {
                            result.Add(newString);
                        }
                        tempWord[i] = cTemp;
                    }

                }
            }
            return result;
        }
        public IList<IList<string>> FindLaddersWrong(string beginWord, string endWord, IList<string> wordList)
        {
            var graph = new Dictionary<string, List<string>>();
            var res = new List<IList<string>>();
            var set = new HashSet<string>(wordList);

            if (!set.Contains(endWord)) return res;

            var q = new Queue<string>();
            q.Enqueue(beginWord);
            var level = 0;
            var found = false;
            while (q.Count > 0)
            {
                var count = q.Count;
                level++;
                for (var i = 0; i < count; i++)
                {
                    var s = q.Dequeue();
                    if (s.Equals(endWord)) found = true;
                    if (!graph.ContainsKey(s)) graph[s] = new List<string>();

                    for (var j = 0; j < s.Length; j++)
                    {
                        var arr = s.ToCharArray();
                        var c = arr[j];
                        for (var k = 0 + 'a'; k <= 0 + 'z'; k++)
                        {
                            if (c == k) continue;
                            arr[j] = (char)k;
                            var newStr = new string(arr);
                            if (set.Contains(newStr))
                            {
                                graph[s].Add(newStr);
                                q.Enqueue(newStr);
                            }
                        }
                        arr[j] = c; //key point 2;
                    }
                }

                if (found) break;
            }

            DfsWrong(res, set ,graph, beginWord, endWord, level, new List<string> { beginWord });
            return res;
        }

        public void DfsWrong(IList<IList<string>> res, HashSet<string> set, Dictionary<string, List<string>> graph, string begin, string end, int level, IList<string> path)
        {

            if (path.Count >= level)
            {
                if (path[path.Count - 1].Equals(end) && path.Count == level) res.Add(new List<string>(path));
                return;
            }

            if (graph.ContainsKey(begin))
            {
                var nexts = graph[begin];
                foreach (var next in nexts)
                {
                    path.Add(next);
                    set.Remove(next);
                    DfsWrong(res, set, graph, next, end, level, path);
                    set.Add(next);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        public IList<IList<string>> FindLaddersTLE2(string beginWord, string endWord, IList<string> wordList)
        {
            var list = new List<IList<string>>();
            var hs = new HashSet<string>(wordList);
            if (!hs.Contains(endWord)) return list; // keypoint 1

            var dict = new Dictionary<string, List<string>>();
            if(!hs.Contains(beginWord))
                wordList.Add(beginWord);

            foreach (var s in wordList)
            {
                var sb = new StringBuilder(s);
                for (var i = 0; i < s.Length; i++)
                {
                    var o = sb[i];
                    foreach (var c in "abcdefghijklmnopqrstuvwxyz")
                    {
                        if (c == o) continue; // key point 3
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
            hs.Remove(beginWord);
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
