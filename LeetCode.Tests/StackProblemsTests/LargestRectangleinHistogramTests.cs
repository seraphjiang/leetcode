using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StackProblems;

namespace LeetCode.Tests.StackProblemsTests
{
    [TestClass]
    public class LargestRectangleinHistogramTests
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=KkJrGxuQtYo
        /// </summary>
        [TestMethod]
        public void Test_LargestRectangleinHistogram1()
        {
            var input = new int[] {2,4,6,5,7,3 };
            var o = new LargestRectangleinHistogram();
            Assert.AreEqual(16, o.LargestRectangleAreaTLE(input));
            Assert.AreEqual(16, o.LargestRectangleArea(input));

            input = new int[] { 3, 5, 5, 2, 5, 5, 6, 6, 4, 4, 1, 1, 2, 5, 5, 6, 6, 4, 1, 3 };
            Assert.AreEqual(24, o.LargestRectangleAreaTLE(input));
            Assert.AreEqual(24, o.LargestRectangleArea(input));
        }
    }
}
