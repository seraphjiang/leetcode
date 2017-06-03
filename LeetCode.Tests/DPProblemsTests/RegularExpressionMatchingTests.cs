using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class RegularExpressionMatchingTests
    {
        [TestMethod]
        public void Test_RegularExpressionMatching1()
        {
            var o = new RegularExpressionMatching();
            Assert.IsFalse(o.IsMatchBackTracking("aa", "a"));
            Assert.IsTrue(o.IsMatchBackTracking("aa", "aa"));
            Assert.IsFalse(o.IsMatchBackTracking("aaa", "aa"));
            Assert.IsTrue(o.IsMatchBackTracking("aa", "a*"));
            Assert.IsTrue(o.IsMatchBackTracking("aa", ".*"));
            Assert.IsTrue(o.IsMatchBackTracking("ab", ".*"));
            Assert.IsTrue(o.IsMatchBackTracking("aab", "c*a*b"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching2()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("aaa", "a*a"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching3()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("aaa", "ab*a*c*a"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching4()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("aaca", "ab*a*c*a"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching5()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("a", "ab*"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching6()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("ab", ".*c"));
        }
        [TestMethod]
        public void Test_RegularExpressionMatching7()
        {
            var o = new RegularExpressionMatching();
            Assert.IsTrue(o.IsMatchBackTracking("bbbba", ".*a*a"));
        }
    }
}
