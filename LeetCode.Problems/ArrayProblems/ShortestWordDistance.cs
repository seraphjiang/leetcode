using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{

    //https://leetcode.com/problems/shortest-word-distance/#/description    
    //Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.

    //For example,
    //Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

    //Given word1 = “coding”, word2 = “practice”, return 3.
    //Given word1 = "makes", word2 = "coding", return 1.

    //Note:
    //You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.


    [Problem(Company = "Linkedin", Level = Level.Easy)]
    public class ShortestWordDistance
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            var last1 = -1;
            var last2 = -1;
            var min = int.MaxValue;
            for (var i = 0; i < words.Length; i++)
            {

                if (words[i].Equals(word1))
                {
                    last1 = i;
                }
                else if (words[i].Equals(word2))
                {
                    last2 = i;
                }

                if (last1 >= 0 && last2 >= 0)
                {
                    min = Math.Min(min, Math.Abs(last2 - last1));
                }

            }

            return min;
        }
    }
}
