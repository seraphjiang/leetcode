using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week36;

namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week36Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var o = new ValidTriangleNumber();
            var input = 1;
            var expected = 1;

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod2()
        {

            var d = new char[2];
            foreach(var x in d)
            {
                Console.WriteLine(x);
            }

            var o = new StringIterator("L1e2t1C1o1d1e1");
            var c = o.Next();
            c = o.Next();
            c = o.Next();
            c = o.Next();
            c = o.Next();
            c = o.Next();
            c = o.Next();
            var h = o.HasNext();
            c = o.Next();
            h = o.HasNext();
            c = o.Next();
            Assert.IsTrue(false);
        }
        [TestMethod]
        public void TestMethod3()
        {
        }
        [TestMethod]
        public void Test_AddBoldTaginString1()
        {
            var o = new AddBoldTaginStringTLE();
            var output = o.AddBoldTag("abcxyz123", new string[] { "abc", "123" });

            Assert.AreEqual("<b>abc</b>xyz<b>123</b>", output);
        }

        [TestMethod]
        public void Test_AddBoldTaginString2()
        {
            var o = new AddBoldTaginStringTLE();
            var output = o.AddBoldTag("aaabbcc", new string[] { "aaa", "aab", "bc", "aaabbcc" });

            Assert.AreEqual("<b>aaabbcc</b>", output);
        }
    }
}
