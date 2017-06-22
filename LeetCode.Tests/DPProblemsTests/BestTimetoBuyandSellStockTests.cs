using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class BestTimetoBuyandSellStockTests
    {
        [TestMethod]
        public void Test_BestTimetoBuyandSellStockIII_1()
        {
            var o = new BestTimetoBuyandSellStockIII();
            Assert.AreEqual(3, o.MaxProfit(new int[] { 2, 1, 4 }));
        }
        [TestMethod]
        public void Test_BestTimetoBuyandSellStockIII_2()
        {
            var o = new BestTimetoBuyandSellStockIII();
            Assert.AreEqual(6, o.MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }));
        }
    }
}
