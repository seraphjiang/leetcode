using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DFSBFS;
using System.Collections.Generic;

namespace LeetCode.Tests.DFSBFS
{
    [TestClass]
    public class RemoveInvalidParenthesesTests
    {
        [TestMethod]
        public void Test_RemoveInvalidParentheses_1()
        {
            var o = new RemoveInvalidParenthesesProblem();

            Assert.AreEqual(new List<string> { "n" }, o.RemoveInvalidParentheses("n"));
        }
    }
}
