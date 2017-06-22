using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class BestTimetoBuyandSellStockII
    {
        public int MaxProfit(int[] prices)
        {
            var total = 0;
            for (var i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i]) total += prices[i + 1] - prices[i];
            }

            return total;
        }

        public int MaxProfit1(int[] prices)
        {
            var max = 0;
            if (prices.Length < 2) return 0;

            if (prices.Length == 2) return prices[0] < prices[1] ? prices[1] - prices[0] : 0;

            int? low = null;
            int? high = null;
            for (var i = 0; i < prices.Length; ++i)
            {
                if (low == null)
                {
                    if (i == 0 && prices[i] < prices[i + 1])
                    {
                        low = prices[i];
                    }
                    else if ((i > 0 && i < prices.Length - 1) && ((prices[i] <= prices[i - 1]) && (prices[i] < prices[i + 1])))
                    {
                        low = prices[i];
                    }
                }
                else
                {
                    if (i == prices.Length - 1 && prices[i] > low)
                    {
                        max += prices[i] - low ?? 0;
                        low = null;
                        high = null;
                    }
                    else if ((i > 0 && i < prices.Length - 1) && (prices[i - 1] < prices[i] && prices[i] >= prices[i + 1]))
                    {
                        max += prices[i] - low ?? 0;
                        low = null;
                    }
                }

            }

            return max;
        }

    }
}
