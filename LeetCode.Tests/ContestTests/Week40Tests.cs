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
            var o = new SolveTheEquation();
            Assert.AreEqual("2", o.SolveEquation("x+5-3+x=6+x-2"));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem2_1()
        {
            var o = new SolveTheEquation();
            Assert.AreEqual("1", o.SolveEquation("-x=-1"));
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem3()
        {
            var o = new ShoppingOffersProblem();
            var act = o.ShoppingOffers(new List<int> { 2, 3, 4 }, new List<IList<int>> { new List<int> { 1, 1, 0, 4 }, new List<int> { 2, 2, 1, 9 } }, new List<int> { 1, 2, 1 });
            Assert.AreEqual(11, act);
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem3_1()
        {
            var o = new ShoppingOffersProblem();
            var act = o.ShoppingOffers(new List<int> { 3, 4 }, new List<IList<int>> { new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 5 } }, new List<int> { 2, 2 });
            Assert.AreEqual(6, act);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "40")]

        public void Test_Contest_Week40_Problem4()
        {
            var o = new LeetCodeProblem4();
        }
    }
}
