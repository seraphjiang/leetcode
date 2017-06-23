using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;
namespace LeetCode.Problems.GreedyProblems
{
    public class CandyProblem
    {
        public int Candy(int[] ratings)
        {
            if (ratings.Length < 2) return ratings.Length;
            var num = new int[ratings.Length];
            for (var i = 0; i < ratings.Length; ++i) num[i] = 1;
            for (var i = 1; i < ratings.Length; ++i)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    num[i] = num[i - 1] + 1;
                }
            }
            for (var i = ratings.Length - 1; i > 0; i--)
            {
                if (ratings[i] < ratings[i - 1])
                {
                    num[i - 1] = Math.Max(num[i - 1], num[i] + 1);
                }
            }

            return num.Sum();
        }
    }
}
