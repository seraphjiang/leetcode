using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week36
{
    /// <summary>
    /// 616. Add Bold Tag in String My SubmissionsBack To Contest
    /// pass 68/70
    /// </summary>
    public class AddBoldTaginStringTLE
    {
        public class Node
        {
            public bool IsEnd;
            public Node[] Children = new Node[256];
        }

        public class Tries
        {
            public Node Root = new Node();

            public void Add(string word)
            {
                var node = Root;

                foreach (var c in word)
                {
                    if (node.Children[(int)c] == null)
                    {
                        node.Children[(int)c] = new Node();
                    }
                    node = node.Children[(int)c];
                }
                node.IsEnd = true;
            }

            public bool StartWith(string str)
            {
                var node = Root;

                for (var i = 0; i < str.Length; i++)
                {
                    if (node.Children[(int)str[i]] == null) return false;
                    node = node.Children[(int)str[i]];
                }

                return true;
            }

            public bool Math(string str)
            {
                var node = Root;

                for (var i = 0; i < str.Length; i++)
                {
                    if (node.Children[(int)str[i]] == null) return false;
                    node = node.Children[(int)str[i]];
                }

                return node.IsEnd;
            }
        }
        public string AddBoldTag(string s, string[] dicts)
        {
            var tries = new Tries();
            foreach (var d in dicts)
            {
                tries.Add(d);
            }

            var dict = new Dictionary<int, int>();
            //for (var i = 0; i < s.Length; i++)
            //{
            //    for (var j = 1; j <= s.Length - i; j++)
            //    {
            //        var sub = s.Substring(i, j);
            //        if (!tries.StartWith(sub)) break;

            //        if (tries.Math(sub))
            //        {
            //            if (!dict.ContainsKey(i)) dict[i] = 0;
            //            dict[i] = j;
            //        }
            //    }
            //}

            var left = 0;
            var right = 0;

            while (left < s.Length && right < s.Length)
            {

            }

            var merge = new Dictionary<int, int>();
            var start = 0;
            var count = 0;

            foreach (var kv in dict)
            {
                if (kv.Key <= (start + count))
                {
                    count = Math.Max(count, kv.Key + kv.Value - start);
                }
                else
                {
                    start = kv.Key;
                    count = kv.Value;
                }

                if (!merge.ContainsKey(start)) merge[start] = 0;
                merge[start] = count;
            }

            var list = new List<int[]>();
            foreach (var kv in merge)
            {
                list.Add(new int[] { kv.Key, kv.Value });
            }
            var sb = new StringBuilder(s);
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var x = list[i][0];
                var y = x + list[i][1];

                sb.Insert(y, "</b>");

                sb.Insert(x, "<b>");
            }

            return sb.ToString();
        }
    }
}
