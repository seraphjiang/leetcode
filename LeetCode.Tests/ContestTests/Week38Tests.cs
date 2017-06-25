using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week38;

namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week38Tests
    {
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem1()
        {
            var o = new Class1();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem2()
        {
            var o = new CourseScheduleIII();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem3()
        {
            var o = new KInversePairsArray();
            Assert.AreEqual(1, o.KInversePairs(3, 0));
            Assert.AreEqual(2, o.KInversePairs(3, 1));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem3_1()
        {
            var o = new KInversePairsArray();
            Assert.AreEqual(1068, o.KInversePairs(10, 5));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem4()
        {
            var o = new Excel(3, 'C');
            Assert.AreEqual(0, o.Get(1, 'A'));
            o.Set(1, 'A', 1);
            Assert.AreEqual(1, o.Get(1, 'A'));
        }
    }
}
