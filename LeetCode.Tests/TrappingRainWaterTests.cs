using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems;

namespace LeetCode.Tests
{
    [TestClass]
    public class TrappingRainWaterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var question = new TrappingRainWater();
            var answer = question.Trap(new int[] { 2, 1, 0, 2 });
            Assert.AreEqual(3, answer);
        }

        [TestMethod]
        public void TestTrapRainWater()
        {
            var question = new TrappingRainWater();
            var answer = question.TrapRainWater(new int[,] {
                { 12, 13, 1, 12 },
                { 13, 4, 13, 12 },
                { 13, 8, 10, 12 },
                { 12, 13, 12, 12 },
                { 13, 13, 13, 13 } });
            Assert.AreEqual(14, answer);
        }

        [TestMethod]
        public void TestTrapRainWater1()
        {
            var question = new TrappingRainWater();
            var answer = question.TrapRainWater(new int[,] {
               {13,16,15,18,15,15},
               {14, 1, 8, 9, 7, 9},
               {19, 5, 4, 2, 5, 10},
               {13, 1, 7, 9, 10, 3},
               {17, 7, 5, 10, 6, 1},
               {15, 9, 8, 2, 8, 3 } });
            Assert.AreEqual(36, answer);
        }
    }
}
