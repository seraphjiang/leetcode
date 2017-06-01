using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ArrayProblems;

namespace LeetCode.Tests.ArrayProblemsTests
{
    [TestClass]
    public class FindFirstMissingPositiveTests
    {
        [TestMethod]
        public void Test_FindFirstMissingPositive1()
        {
            var input = new int[] { 1, 1 };
            var o = new FindFirstMissingPositive();
            Assert.AreEqual(2, o.FirstMissingPositive(input));

            Assert.AreEqual(1, o.FirstMissingPositive(new int[] { 0}));

            Assert.AreEqual(3, o.FirstMissingPositive(new int[] { 2,1 }));

        }
    }
}
