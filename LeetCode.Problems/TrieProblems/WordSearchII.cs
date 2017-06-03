using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.TrieProblems
{
    public class WordSearchII
    {
        int m;
        int n;
        public IList<string> FindWords(char[,] board, string[] words)
        {
            m = board.GetLength(0);
            n = board.GetLength(1);
            var res = new HashSet<string>();
            var t = new Trie(words);

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    var visitied = new bool[m, n];
                    var s = board[i, j].ToString();
                    if (!t.StartWith(s)) continue;
                    Dfs(board, i, j, t, visitied, s, res);
                }
            }

            return new List<string>(res);
        }

        int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        public void Dfs(char[,] board, int x, int y, Trie t, bool[,] visitied, string s, HashSet<string> result)
        {
            if (visitied[x, y]) return;
            visitied[x, y] = true;
            if (t.Math(s))
            {
                result.Add(s);
            }

            for (var i = 0; i < 4; i++)
            {
                var r = x + directions[i, 0];
                var c = y + directions[i, 1];

                if (r < 0 || r >= m || c < 0 || c >= n || visitied[r, c]) continue;

                var s2 = s + board[r, c];
                if (t.StartWith(s2))
                {
                    Dfs(board, r, c, t, visitied, s2, result);
                    visitied[r, c] = false;
                }
            }
        }

        public class TrieNode
        {
            public TrieNode[] Children = new TrieNode[26];
            public char? Value = null;
            public bool IsEnd;
        }

        public class Trie
        {
            TrieNode Root;
            public Trie(string[] words)
            {
                this.Root = new TrieNode();
                foreach (var word in words)
                {
                    this.Build(word);
                }
            }

            public void Build(string word)
            {
                var node = this.Root;
                foreach (var c in word)
                {
                    var key = c - 'a';
                    if (node.Children[key] == null)
                    {
                        node.Children[key] = new TrieNode() { Value = c};
                    }
                    node = node.Children[key];
                }
                node.IsEnd = true;
            }

            public bool StartWith(string s)
            {
                var node = this.Root;
                foreach (var c in s)
                {
                    var key = c - 'a';
                    if (node.Children[key] == null) return false;
                    node = node.Children[key];
                }

                return true;
            }

            public bool Math(string s)
            {
                var node = this.Root;
                foreach (var c in s)
                {
                    var key = c - 'a';
                    if (node.Children[key] == null) return false;
                    node = node.Children[key];
                }

                return node.IsEnd;
            }
        }
    }
}
