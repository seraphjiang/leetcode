using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BacktrackingProblems;

namespace LeetCode.Tests.BacktrackingProblemsTests
{
    [TestClass]
    public class NQueensTests
    {
        [TestMethod]
        public void Test_NQueen_1()
        {
            var o = new NQueens();

            Assert.AreEqual(2, o.SolveNQueens(4).Count);
        }
    }
}
