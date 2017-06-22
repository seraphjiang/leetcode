using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class BestTimetoBuyandSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;
            k = Math.Min(k, prices.Length);

            var global = new int[k + 1];
            var local = new int[k + 1];

            for (var i = 1; i < prices.Length; ++i)
            {
                var diff = prices[i] - prices[i - 1];

                // Out of Memory
                //for (var j = 1; j <= k; ++j)
                //{
                //    local[i, j] = Math.Max(local[i - 1, j] + diff, global[i - 1, j - 1] + Math.Max(diff, 0));
                //    global[i, j] = Math.Max(local[i, j], global[i - 1, j]);
                //}

                for (var j = k; j >= 1; j--)
                {
                    local[j] = Math.Max(local[j] + diff, global[j - 1] + Math.Max(diff, 0));
                    global[j] = Math.Max(local[j], global[j]);
                }
            }

            return global[k];
        }

    }
}
