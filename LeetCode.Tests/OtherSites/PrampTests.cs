using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtherSites.Problems.Pramp;

namespace LeetCode.Tests.OtherSites
{
    [TestClass]
    public class PrampTests
    {
        [TestMethod]
        [TestProperty("pramp.com", "DecryptMessage")]
        public void Test_Pramp_DecryptMessage_1()
        {
            var o = new DecryptMessage();
            Assert.AreEqual("crime", o.Decrypt("dnotq"));
        }

        [TestMethod]
        [TestProperty("pramp.com", "SmallestSubstringofAllCharacters")]
        public void Test_Pramp_SmallestSubstringofAllCharacters_1()
        {
            var o = new SmallestSubstringofAllCharacters();
            Assert.AreEqual("abbc", o.GetShortestUniqueSubstring(new char[] { 'a', 'b', 'c' }, "aabbcc"));
        }
        [TestMethod]
        [TestProperty("pramp.com", "SmallestSubstringofAllCharacters")]
        public void Test_Pramp_SmallestSubstringofAllCharacters_2()
        {
            var o = new SmallestSubstringofAllCharacters();
            Assert.AreEqual("a", o.GetShortestUniqueSubstring(new char[] { 'a' }, "a"));
        }
    }
}
