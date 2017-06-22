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
        public int MaxProfit(int[] prices)
        {
            return MaxProfit(prices, 2);
        }

        public int MaxProfit(int[] prices, int k)
        {
            if (prices == null || prices.Length < 2) return 0;

            var global = new int[prices.Length, k + 1];
            var local = new int[prices.Length, k + 1];

            for (var i = 1; i < prices.Length; ++i)
            {
                var diff = prices[i] - prices[i - 1];
                for (var j = 1; j <= k; ++j)
                {
                    //local[i, j] = Math.Max(local[i - 1, j - 1] + Math.Max(diff, 0), global[i - 1, j - 1] + diff);
                    local[i, j] = Math.Max(local[i - 1, j] + diff, global[i - 1, j - 1] + Math.Max(diff, 0));
                    global[i, j] = Math.Max(local[i, j], global[i - 1, j]);
                }
            }

            return global[prices.Length - 1, k];
        }

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
