using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.GreedyProblems;

namespace LeetCode.Tests.GreedyProblemsTests
{
    [TestClass]
    public class WildcardMatchTests
    {
        [TestMethod]
        public void Test_WildcharMatch1()
        {
            var o = new WildcardMath();
            Assert.IsTrue(o.IsMatch("aa", "*"));
        }
    }
}
