using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;
using Commons;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class MaximalRectangleTests
    {
        [TestMethod]
        public void Test_MaximalRectangleProblem_1()
        {
            var input = new char[][]
            {
                "10100".ToCharArray(),
                "10111".ToCharArray(),
                "11111".ToCharArray(),
                "10010".ToCharArray()
            };
            
            var o = new MaximalRectangleProblem();
            Assert.AreEqual(6, o.MaximalRectangle(input.To2D()));
        }
    }
}
