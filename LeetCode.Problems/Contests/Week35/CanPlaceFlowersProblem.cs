using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week35
{
    public class CanPlaceFlowersProblem
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (var i = 0; i < flowerbed.Length; ++i)
            {
                if (flowerbed[i] == 1) continue;

                if (i == 0 && i == flowerbed.Length - 1 && flowerbed[0] == 0)
                {
                    return n - 1 <= 0;
                }
                else if (i == 0 && i + 1 < flowerbed.Length && flowerbed[i + 1] == 0)
                {
                    flowerbed[i] = 1;
                    n--;
                }
                else if (i == flowerbed.Length - 1 && i - 1 >= 0 && flowerbed[i - 1] == 0)
                {
                    flowerbed[i] = 1;
                    n--;
                }
                else if (i > 0 && i < flowerbed.Length - 1 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
                {
                    flowerbed[i] = 1;
                    n--;
                }
                if (n <= 0) return true;
            }

            return n <= 0;
        }
    }
}
