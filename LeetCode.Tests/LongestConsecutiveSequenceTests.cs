using System;
using LeetCode.Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Tests
{
    [TestClass]
    public class LongestConsecutiveSequenceTests
    {
        [TestMethod]
        public void Test_LongestConsecutive()
        {
            var nums = new int[] { 1, 2, 0, 1 };
            var actual = (new LongestConsecutiveSequence()).LongestConsecutive(nums);
            var expect = 3;

            Assert.AreEqual(expect, actual);
        }
    }
}
