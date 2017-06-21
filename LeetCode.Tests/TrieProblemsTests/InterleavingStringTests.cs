using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.TrieProblemsTests
{
    [TestClass]
    public class InterleavingStringTests
    {
        [TestMethod]
        public void Test_InterleavingString_1()
        {
            var o = new InterleavingString();
            Assert.IsTrue(o.IsInterleave("ab", "bc", "babc"));
        }
    }
}
