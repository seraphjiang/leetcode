using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week42;
using System.Collections.Generic;
using Commons;
namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week42Tests
    {
        [TestMethod]
        [TestProperty("WeeklyContest", "42")]

        public void Test_Contest_Week42_Problem1()
        {
            var o = new LeetCodeProblem1();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "42")]

        public void Test_Contest_Week42_Problem2()
        {
            var o = new LeetCodeProblem2();
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "42")]

        public void Test_Contest_Week42_Problem2_1()
        {
            var o = new LeetCodeProblem2();

        }

        [TestMethod]
        [TestProperty("WeeklyContest", "42")]

        public void Test_Contest_Week42_Problem3()
        {
            var o = new LeetCodeProblem3();
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "42")]

        public void Test_Contest_Week42_Problem4()
        {
            var o = new LeetCodeProblem4();
        }
    }
}
