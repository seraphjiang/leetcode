using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class EditDistanceTests
    {
        [TestMethod]
        public void Test_EditDistance_1()
        {
            var o = new EditDistance();
            Assert.AreEqual(0, o.MinDistance("a", "a"));
            Assert.AreEqual(1, o.MinDistance("a", "aa"));
            Assert.AreEqual(1, o.MinDistance("a", "b"));
        }
    }
}
