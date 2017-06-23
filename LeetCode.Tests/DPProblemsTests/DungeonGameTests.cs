using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class DungeonGameTests
    {
        [TestMethod]
        public void Test_DungeonGame_1()
        {
            var input = new[,]{
                {-2,-3,3},
                {-5,-10,1},
                {10,30,-5}
             };
            var o = new DungeonGame();
            Assert.AreEqual(7, o.CalculateMinimumHP(input));
        }
        [TestMethod]
        public void Test_DungeonGame_2()
        {
            var input = new[,]{
                {0,-3},
             };
            var o = new DungeonGame();
            Assert.AreEqual(4, o.CalculateMinimumHP(input));
        }
        [TestMethod]
        public void Test_DungeonGame_3()
        {
            var input = new[,]{
                {3,-20,30},
                {-3,4,0},
             };
            var o = new DungeonGame();
            Assert.AreEqual(1, o.CalculateMinimumHP(input));
        }
        [TestMethod]
        public void Test_DungeonGame_4()
        {
            var input = new[,]{
                {1,-3,3},
                {0,-2,0},
                {-3,-3,-3 }
             };
            var o = new DungeonGame();
            Assert.AreEqual(3, o.CalculateMinimumHP(input));
        }
    }
}
