using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    /// <summary>
    /// http://blog.csdn.net/fightforyourdream/article/details/14503469
    /// http://blog.csdn.net/linhuanmars/article/details/23236995
    /// http://www.cnblogs.com/grandyang/p/4281975.html
    /// </summary>
    public class BestTimetoBuyandSellStockIII
    {
        public int MaxProfitDPSolution1(int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;
            var left = new int[prices.Length];
            var right = new int[prices.Length];

            var min = prices[0];
            for (var i = 1; i < prices.Length; i++)
            {
                left[i] = Math.Max(left[i - 1], prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            var max = prices[prices.Length - 1];
            for (var i = prices.Length - 2; i >= 0; i--)
            {
                right[i] = Math.Max(right[i + 1], max - prices[i]);
                max = Math.Max(max, prices[i]);
            }

            max = 0;
            for (var i = 0; i < prices.Length; i++)
            {
                max = Math.Max(max, left[i] + right[i]);
            }

            return max;
        }
    }
}
