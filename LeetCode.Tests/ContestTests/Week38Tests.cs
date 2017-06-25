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
            var o = new MaximumProductofThreeNumbers();
            var exp = 1;

            Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem2()
        {
            var o = new CourseScheduleIII();
            Assert.AreEqual(1, o.ScheduleCourse(new int[,] { { 1, 2 } }));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem2_1()
        {
            var o = new CourseScheduleIII();
            Assert.AreEqual(3, o.ScheduleCourse(new int[,] {
                { 100, 200 },
            { 200,1300},
            { 1000,1250},
            {2000,3000 } }));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem2_2()
        {
            var o = new CourseScheduleIII();
            Assert.AreEqual(3, o.ScheduleCourse(new int[,] {
                { 9, 14 },
            { 7,12},
            { 1,11},
            { 4,7 }}));
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem2_3()
        {
            var o = new CourseScheduleIII();
            Assert.AreEqual(4, o.ScheduleCourse(new int[,]{{7, 17},{3, 12},{10, 20},{9, 10},{5, 20},{10, 19},{4, 18}}));
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
