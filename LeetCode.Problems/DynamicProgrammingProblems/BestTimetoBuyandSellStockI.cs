using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class BestTimetoBuyandSellStockI
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            var min = prices[0];
            var max = 0;
            foreach (var p in prices)
            {
                if (min > p) min = p;
                if (max < (p - min)) max = (p - min);
            }

            return max;
        }
    }
}
