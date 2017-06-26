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
    }
}
