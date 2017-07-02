using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week39;
using System.Collections.Generic;
using Commons;
namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week39Tests
    {
        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem1()
        {
            var o = new Class1();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem2()
        {
            var o = new Class2();
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem2_1()
        {
            var o = new Class2();

        }

        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem3()
        {
            var o = new Class3();
        }
     
        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem4()
        {
            var o = new Class4();
        }
    }
}
