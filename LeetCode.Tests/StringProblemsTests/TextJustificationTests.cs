using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.StringProblemsTests
{
    [TestClass]
    public class TextJustificationTests
    {
        [TestMethod]
        public void Test_TextJustification_1()
        {
            var input = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            var o = new TextJustification();
            var act = o.FullJustify(input, 16);
            Assert.AreEqual(3, act.Count);
        }
        [TestMethod]
        public void Test_TextJustification_2()
        {
            var input = new string[] { "a", "c", "c"};
            var o = new TextJustification();
            var act = o.FullJustify(input, 1);
            Assert.AreEqual(3, act.Count);
        }
    }
}
