using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Amazon
{

// https://www.geeksforgeeks.org/find-the-number-of-distinct-islands-in-a-2d-matrix/
/*
Find the number of distinct islands in a 2D matrix
Given a boolean 2D matrix. The task is to find the number of distinct islands where a group of connected 1s (horizontally or vertically) forms an island. Two islands are considered to be distinct if and only if one island is equal to another (not rotated or reflected).

Examples:

Input: grid[][] =
{{1, 1, 0, 0, 0},
1, 1, 0, 0, 0},
0, 0, 0, 1, 1},
0, 0, 0, 1, 1}}

Output: 1
Island 1, 1 at the top left corner is same as island 1, 1 at the bottom right corner

Input: grid[][] =
{{1, 1, 0, 1, 1},
1, 0, 0, 0, 0},
0, 0, 0, 0, 1},
1, 1, 0, 1, 1}}

Output: 3
Distinct islands in the example above are: 1, 1 at the top left corner; 1, 1 at the top right corner and 1 at the bottom right corner. We ignore the island 1, 1 at the bottom left corner since 1, 1 it is identical to the top right corner.

*/

// https://leetcode.com/problems/number-of-distinct-islands/solution/
//
    public class FindCoundSharpOfIsland
    {
        /// <summary>
        /// Given a 2d matrix with each element value is either 0 or 1.
        /// 0 means water
        /// 1 means land
        /// land can only be joint when another land is at up, down, right, left direction
        /// diagonal land is not joint
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public Dictionary<string, int> Count(int[,] matrix)
        {
            return null;
        }
    }
}
