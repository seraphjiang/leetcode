using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{

    // https://leetcode.com/problems/paint-house/#/description
    //    There are a row of n houses, each house can be painted with one of the three colors: red, blue or green.The cost of painting each house with a certain color is different.You have to paint all the houses such that no two adjacent houses have the same color.
    //The cost of painting each house with a certain color is represented by a n x 3 cost matrix.For example, costs[0][0] is the cost of painting house 0 with color red; costs[1][2] is the cost of painting house 1 with color green, and so on...Find the minimum cost to paint all houses.
    //Note:
    //All costs are positive integers.

    [Problem(Company = "Linkedin", Level = Level.Easy)]
    public class PaintHouse
    {
        public int MinCost(int[,] costs)
        {
            int red = 0, blue = 0, green = 0;
            var n = costs.GetLength(0);
            for (var i = 0; i < n; i++)
            {
                var r = Math.Min(blue, green) + costs[i, 0];
                var b = Math.Min(red, green) + costs[i, 1];
                var g = Math.Min(red, blue) + costs[i, 2];

                red = r;
                blue = b;
                green = g;
            }
            return Math.Min(red, Math.Min(blue, green));
        }

        public int MinCostTLE(int[,] costs)
        {
            if (costs.GetLength(0) == 0) return 0;
            var colors = new int[costs.GetLength(0)];
            return BackTrack(costs, 0, 0, colors);
        }

        public int BackTrack(int[,] costs, int index, int total, int[] colors)
        {
            if (index == colors.Length) return total;
            var min = int.MaxValue;
            for (var i = 0; i < 3; i++)
            {
                colors[index] = i;
                if (index > 0 && colors[index - 1] == i) continue;
                min = Math.Min(min, BackTrack(costs, index + 1, total + costs[index, i], colors));
            }

            return min;
        }
    }
}