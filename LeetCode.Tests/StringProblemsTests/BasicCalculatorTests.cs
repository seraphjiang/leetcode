using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.StringProblemsTests
{
    [TestClass]
    public class BasicCalculatorTests
    {
        [TestMethod]
        public void Test_BasicCalculator1()
        {
            var o = new BasicCalculator();
            Assert.AreEqual(2, o.Calculate(" 1 + 1 "));
        }
        [TestMethod]
        public void Test_BasicCalculator2()
        {
            var o = new BasicCalculator();
            Assert.AreEqual(-15, o.Calculate("2-4-(8+2-6+(8+4-(1)+8-10))"));
        }
        [TestMethod]
        public void Test_BasicCalculator3()
        {
            var o = new BasicCalculator();
            Assert.AreEqual(1, o.Calculate("(1)"));
        }
        [TestMethod]
        public void Test_BasicCalculator4()
        {
            var o = new BasicCalculator();
            Assert.AreEqual(4, o.Calculate("(3)+1"));
        }
        [TestMethod]
        public void Test_BasicCalculator5()
        {
            var o = new BasicCalculator();
            Assert.AreEqual(3, o.Calculate("   (  3 ) "));
        }
    }
}
