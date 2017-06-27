using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BacktrackingProblems;

namespace LeetCode.Tests.BacktrackingProblemsTests
{
    [TestClass]
    public class ExpressionAddOperatorsTests
    {
        [TestMethod]
        public void Test_ExpressionAddOperators_1()
        {
            var o = new ExpressionAddOperators();
            Assert.AreEqual(new string[] { "1*0+5", "10-5" }, o.AddOperators("105", 5));
        }
    }
}
