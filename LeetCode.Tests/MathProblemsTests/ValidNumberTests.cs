using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.MathProblems;

namespace LeetCode.Tests.MathProblemsTests
{
    [TestClass]
    public class ValidNumberTests
    {
        [TestMethod]
        public void Test_ValidNumber_1()
        {
            var o = new ValidNumber();
            Assert.IsTrue(o.IsNumber("3"));

            Assert.IsFalse(o.IsNumber(""));
            Assert.IsTrue(o.IsNumber("123"));
            Assert.IsFalse(o.IsNumber("e9"));
        }
    }
}
