using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.StringProblemsTests
{
    [TestClass]
    public class BasicCalculatorIITests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var o = new BasicCalculatorII();
            var actual = o.Calculate("2*2");
            Assert.Equals(-4, actual);
        }
    }
}
