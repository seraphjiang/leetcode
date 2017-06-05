using System;
using LeetCode.Problems.Contests.Week35;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week35Tests
    {
        [TestMethod]
        public void Test_Contest_Week35_Problem1()
        {
            var o = new CanPlaceFlowersProblem();
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem2()
        {
            var o = new ConstructStringfromBinaryTree();
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem3()
        {
            var o = new FindDuplicateFileinSystem();
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4()
        {
            var o = new TagValidator();
            var input = "<DIV>This is the first line <![CDATA[<div>]]></DIV>";
            var innnt = "<DIV>This is the first line <![CDATA[<div>]]><DIV>";
            // "<DIV>>>>>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>"
            Assert.IsTrue(o.IsValid(input));
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4_1()
        {
            var o = new TagValidator();
            var input = "<DIV>>>>>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>";

            Assert.IsTrue(o.IsValid(input));
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4_2()
        {
            var o = new TagValidator();
            var input = "<![CDATA[wahaha]]]><![CDATA[]> wahaha]]>";

            Assert.IsFalse(o.IsValid(input));
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4_3()
        {
            var o = new TagValidator();
            var input = "<A></A><B></B>";

            Assert.IsFalse(o.IsValid(input));
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4_4()
        {
            var o = new TagValidator();
            var input = "<A<></A<>";

            Assert.IsFalse(o.IsValid(input));
        }
        [TestMethod]
        public void Test_Contest_Week35_Problem4_5()
        {
            var o = new TagValidator();
            var input = "<A></A>>";

            Assert.IsFalse(o.IsValid(input));
        }
    }
}
