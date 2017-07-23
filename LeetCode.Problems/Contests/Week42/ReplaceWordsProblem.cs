using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week42
{
    [Problem(Company = "Uber", Level = Level.Hard)]
    public class ReplaceWordsProblem
    {
        Trie root = new Trie();
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var arr = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            BuildTree(dict);
            for (var i = 0; i < arr.Length; i++)
            {
                var replace = FindMatch(arr[i]);
                if (replace != null) arr[i] = replace;
            }

            return string.Join(" ", arr);
        }

        public void BuildTree(IList<string> dict)
        {
            for (var i = 0; i < dict.Count; i++)
            {
                var node = root;
                var word = dict[i];

                for (var j = 0; j < word.Length; j++)
                {
                    if (node.Children[(int)word[j]] == null) node.Children[(int)word[j]] = new Trie();
                    node = node.Children[(int)word[j]];
                }
                node.IsEnd = true;
                node.Word = word;
            }
        }

        public string FindMatch(string word)
        {
            var node = root;
            for (var i = 0; i < word.Length; i++)
            {
                if (node.Children[word[i]] == null) return null;
                if (node.Children[word[i]].IsEnd) return node.Children[word[i]].Word;
                node = node.Children[word[i]];
            }

            return null;
        }
        public class Trie
        {
            public Trie[] Children = new Trie[128];
            public bool IsEnd;
            public string Word;
        }
    }
}
