using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
//    Given a picture consisting of black and white pixels, find the number of black lonely pixels.

//The picture is represented by a 2D char array consisting of 'B' and 'W', which means black and white pixels respectively.

//A black lonely pixel is character 'B' that located at a specific position where the same row and same column don't have any other black pixels.

//Example:
//Input: 
//[['W', 'W', 'B'],
// ['W', 'B', 'W'],
// ['B', 'W', 'W']]

//Output: 3
//Explanation: All the three 'B's are black lonely pixels.
//Note:
//The range of width and height of the input 2D array is [1,500].
    [Problem(Company = "Google", Level = Level.Median)]
    public class LonelyPixelI
    {
        public int FindLonelyPixel(char[,] picture)
        {
            var m = picture.GetLength(0);
            var n = picture.GetLength(1);
            var rows = new int[m];
            var cols = new int[n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (picture[i, j] == 'B') { rows[i]++; cols[j]++; }
                }
            }

            var total = 0;
            for (var i = 0; i < m; i++)
            {
                if (rows[i] != 1) continue;
                for (var j = 0; j < n; j++)
                {
                    if (cols[j] != 1) continue;
                    if (picture[i, j] == 'B') total++;
                }
            }

            return total;
        }
    }
}
