using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BacktrackingProblems
{

    //https://leetcode.com/problems/flip-game/#/description
    //You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.
    //Write a function to compute all possible states of the string after one valid move.
    //For example, given s = "++++", after one move, it may become one of the following states:
    //If there is no valid move, return an empty list[].

    [Problem(Company = "Google", Level = Level.Easy)]
    public class FlipGame
    {
        public IList<string> GeneratePossibleNextMoves(string s)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(s) || s.Length == 1) return list;
            var arr = s.ToCharArray();
            for (var i = 0; i < s.Length - 1; i++)
            {
                if (arr[i] == '+' && arr[i + 1] == '+')
                {
                    arr[i] = '-'; arr[i + 1] = '-';
                    list.Add(new string(arr));
                    arr[i] = '+'; arr[i + 1] = '+';
                }
            }
            return list;
        }
    }
}