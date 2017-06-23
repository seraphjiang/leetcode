using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ArrayProblems;

namespace LeetCode.Tests.ArrayProblemsTests
{
    [TestClass]
    public class MaximumGapTests
    {
        [TestMethod]
        public void Test_MaximumGapProblem_1()
        {
            var o = new MaximumGapProblem();
            Assert.AreEqual(10000 - 1, o.MaximumGap(new int[] { 1, 10000 }));
        }
    }
}
