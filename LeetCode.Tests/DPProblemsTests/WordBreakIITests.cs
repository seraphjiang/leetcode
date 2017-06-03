using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;
using System.Collections.Generic;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class WordBreakIITests
    {
        [TestMethod]
        public void Test_WordBreakII1()
        {
            var o = new WordBreakII();
            var expected = new List<string> { "cats and dog", "cat sand dog" };
            var actual = o.WordBreak("catsanddog", new List<string> { "cat", "cats", "and", "sand", "dog" });
            Assert.IsTrue(AreTheSameIgnoringOrder(expected, actual));
        }
        public static bool AreTheSameIgnoringOrder(IList<string> x, IList<string> y)
        {
            return x.Count() == y.Count()
                && !x.Except(y).Any()
                && !y.Except(x).Any();
        }

        [TestMethod]
        public void Test_WordBreakII2()
        {
            var o = new WordBreakII();
            var expected = new List<string> {  };
            var actual = o.WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
            Assert.IsTrue(AreTheSameIgnoringOrder(expected, actual));
        }
    }
}
