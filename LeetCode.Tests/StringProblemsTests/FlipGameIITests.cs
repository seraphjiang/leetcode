using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.StringProblemsTests
{
    [TestClass]
    public class FlipGameIITests
    {
        [TestMethod]
        public void Test_FlipGameII_1()
        {
            var o = new FlipGameII();
            Assert.IsTrue(o.CanWin("++++"));
        }
    }
}
