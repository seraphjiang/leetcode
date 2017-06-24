using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.MathProblems;

namespace LeetCode.Tests.MathProblemsTests
{
    [TestClass]
    public class NumberofDigitOneTests
    {
        [TestMethod]
        public void Test_NumberofDigitOne_1()
        {
            var o = new NumberofDigitOne();
            Assert.AreEqual(6, o.CountDigitOne(13));
        }
        [TestMethod]
        public void Test_NumberofDigitOne_2()
        {
            var o = new NumberofDigitOne();
            Assert.AreEqual(301, o.CountDigitOne(1000));
        }
        [TestMethod]
        public void Test_NumberofDigitOne_3()
        {
            var o = new NumberofDigitOne();
            Assert.AreEqual(21, o.CountDigitOne(100));
        }
    }
}
