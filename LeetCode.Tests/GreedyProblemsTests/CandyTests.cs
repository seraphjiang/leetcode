using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.GreedyProblems;

namespace LeetCode.Tests.GreedyProblemsTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void Test_Candy_1()
        {
            var o = new CandyProblem();
            Assert.AreEqual(4, o.Candy(new int[] { 1, 2, 2 }));
        }
    }
}