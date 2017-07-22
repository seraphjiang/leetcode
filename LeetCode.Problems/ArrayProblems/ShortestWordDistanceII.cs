using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{

    //https://leetcode.com/problems/shortest-word-distance-ii/#/description
    //This is a follow up of Shortest Word Distance.The only difference is now you are given the list of words and your method will be called repeatedly many times with different parameters.How would you optimize it?
    //Design a class which receives a list of words in the constructor, and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list.
    //For example,
    //Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
    //Given word1 = “coding”, word2 = “practice”, return 3.
    //Given word1 = "makes", word2 = "coding", return 1.
    //Note:
    //You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.

    [Problem(Company = "Linkedin", Level = Level.Easy)]
    public class WordDistance
    {
        Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
        public WordDistance(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                if (!dict.ContainsKey(words[i])) dict[words[i]] = new List<int>();
                dict[words[i]].Add(i);
            }
        }

        public int Shortest(string word1, string word2)
        {
            var last1 = dict[word1]; var last2 = dict[word2];

            var min = int.MaxValue;
            for (int i = 0, j = 0; i < last1.Count && j < last2.Count;)
            {
                if (last1[i] < last2[j])
                {
                    min = Math.Min(min, last2[j] - last1[i]);
                    i++;
                }
                else
                {
                    min = Math.Min(min, last1[i] - last2[j]);
                    j++;
                }
            }

            return min;
        }
    }

    public class WordDistanceTLE
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public WordDistanceTLE(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                for (var j = 0; j < words.Length; j++)
                {
                    if (i == j || words[i].Equals(words[j])) continue;
                    var key = words[i].CompareTo(words[j]) >= 0 ? string.Format("{0},{1}", words[i], words[j]) : string.Format("{0},{1}", words[j], words[i]);
                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = Math.Abs(i - j);
                    }
                    else
                    {
                        dict[key] = Math.Min(dict[key], Math.Abs(i - j));
                    }
                }
            }
        }

        public int Shortest(string word1, string word2)
        {
            var key = word1.CompareTo(word2) >= 0 ? string.Format("{0},{1}", word1, word2) : string.Format("{0},{1}", word2, word1);
            return dict[key];
        }
    }
}