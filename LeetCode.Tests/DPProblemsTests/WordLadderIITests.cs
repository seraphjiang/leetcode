using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BacktrackingProblems;
using System.Collections.Generic;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class WordLadderIITests
    {
        [TestMethod]
        public void Test_WordLadderII_1()
        {
            var o = new WordLadderII();
            var act = o.FindLadders("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });
            Assert.AreEqual(2, act.Count);
        }
    }
}
