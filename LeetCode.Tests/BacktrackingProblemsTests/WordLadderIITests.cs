using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BacktrackingProblems;
using System.Collections.Generic;
using System.Linq;
namespace LeetCode.Tests.BacktrackingProblemsTests
{
    [TestClass]
    public class WordLadderIITests
    {
        [TestMethod]
        public void Test_WordLadderII_1()
        {
            var o = new WordLadderII();
            var act = o.FindLadders("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });
        }

        [TestMethod]
        public void Test_WordLadderII_2()
        {
            var o = new WordLadderII();
            var act = o.FindLadders("a", "c", new List<string> { "a", "b", "c" });
            var list = new List<IList<string>> { new List<string> { "a", "c" } };
            Assert.IsTrue(act.SequenceEqual(list));
        }
    }
}
