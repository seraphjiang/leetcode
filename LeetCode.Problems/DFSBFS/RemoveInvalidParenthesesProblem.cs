using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DFSBFS
{
    public class RemoveInvalidParenthesesProblem
    {
        public IList<string> RemoveInvalidParenthesesBFS(string s)
        {
            if (string.IsNullOrEmpty(s)) return new List<string> { s };
            var res = new List<string>();
            var hs = new HashSet<string>();
            var q = new Queue<string>();
            q.Enqueue(s);
            hs.Add(s);
            var found = false;
            while (q.Count > 0)
            {
                var count = q.Count;
                for (var j = 0; j < count; j++)
                {
                    var n = q.Dequeue();
                    if (IsValid(n))
                    {
                        found = true;
                        res.Add(n);
                    }
                    if (found) continue;

                    for (var i = 0; i < n.Length; ++i)
                    {
                        if (s[i] != '(' && s[i] != ')') continue;
                        var n1 = new StringBuilder(n);
                        n1.Remove(i, 1);
                        var newStr = n1.ToString();

                        if (!hs.Contains(newStr))
                        {
                            q.Enqueue(newStr);
                            hs.Add(newStr);
                        }
                    }
                }
                if (found) break;
            }

            return res.ToList();
        }

        bool IsValid(string s)
        {
            var stack = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(') stack++;
                else if (s[i] == ')' && stack-- == 0) return false;
            }

            return stack == 0;
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            var res = new List<string>();
            Remove(s, res, 0, 0, new char[] { '(', ')' });
            return res;
        }

        void Remove(string s, List<string> res, int lasti, int lastj, char[] par)
        {
            for (int stack = 0, i = lasti; i < s.Length; i++)
            {
                if (s[i] == par[0]) stack++;
                if (s[i] == par[1]) stack--;
                if (stack >= 0) continue;
                for (var j = lastj; j <= i; ++j)
                {
                    if (s[j] == par[1] && (j == lastj || s[j - 1] != par[1]))
                    {
                        var sb = new StringBuilder(s);
                        sb.Remove(j, 1);
                        Remove(sb.ToString(), res, i, j, par);
                    }
                }
                return;  //don't forget this; otherwise there will be duplicated
            }

            var reversed = new string(s.ToCharArray().Reverse().ToArray());
            if (par[0] == '(')
                Remove(reversed, res, 0, 0, new char[] { ')', '(' });
            else
                res.Add(reversed);
        }


        int min;
        public IList<string> RemoveInvalidParenthesesTLE(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new List<string> { "" };
            }
            var sb = new StringBuilder(s);
            var res = new HashSet<string>();

            if (IsValid(sb))
            {
                return new List<string> { s };
            }
            min = s.Length;

            Dfs(res, sb, sb);
            if (res.Count == 0) return new List<string> { s };
            return new List<string>(res);
        }
        bool IsValid(StringBuilder sb)
        {
            var stack = new Stack<char>();
            for (var i = 0; i < sb.Length; i++)
            {
                var c = sb[i];
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count <= 0) return false;
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
        public void Dfs(HashSet<string> res, StringBuilder sb, StringBuilder cur)
        {
            if (IsValid(cur))
            {
                if (sb.Length - cur.Length > min) return;
                if (sb.Length - cur.Length < min) res.Clear();
                min = sb.Length - cur.Length;
                res.Add(cur.ToString());
                return;
            }

            for (var i = 0; i < cur.Length; i++)
            {
                if (sb.Length - cur.Length + 1 > min) break;
                if (cur[i] != '(' && cur[i] != ')') continue;
                var copy = new StringBuilder(cur.ToString());
                copy.Remove(i, 1);
                Dfs(res, sb, copy);
            }
        }
    }
}
