using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Commons;
using LeetCode.Problems.Contests.Week40;

namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week40Tests
    {
        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem1()
        {
            var o = new LeetCodeProblem1();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem2()
        {
            var o = new LeetCodeProblem2();
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem2_1()
        {
            var o = new LeetCodeProblem2();

        }

        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem3()
        {
            var o = new LeetCodeProblem3();
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem4()
        {
            var o = new LeetCodeProblem4();
        }
    }
}
