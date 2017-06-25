using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.MathProblems;

namespace LeetCode.Tests.MathProblemsTests
{
    [TestClass]
    public class IntegertoEnglishWordsTests
    {
        [TestMethod]
        public void Test_IntegertoEnglishWords_1()
        {
            var o = new IntegertoEnglishWords();
            Assert.AreEqual("One Billion", o.NumberToWords(1000000000));
        }
    }
}
