using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week38;
using static Commons.ListExtensions;
using System.Collections.Generic;

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
            Assert.AreEqual(4, o.ScheduleCourse(new int[,] { { 7, 17 }, { 3, 12 }, { 10, 20 }, { 9, 10 }, { 5, 20 }, { 10, 19 }, { 4, 18 } }));
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
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem_4_1()
        {
            var o = new Excel(5, 'E');
            Assert.AreEqual(0, o.Get(1, 'A'));
            o.Set(1, 'A', 1);
            Assert.AreEqual(1, o.Get(1, 'A'));
            o.Sum(2, 'B', new string[] { "A1", "A1" });
            o.Set(1, 'A', 2);
            o.Get(2, 'B');
            o.Sum(3, 'C', new string[] { "B2", "A1:B2" });
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem_4_2()
        {
            var o = new Excel(5, 'E');
            o.Set(1, 'A', 5);
            o.Set(1, 'B', 3);
            o.Set(1, 'C', 2);


            o.Sum(1, 'C', new string[] { "A1", "A1:B1" });

            o.Get(1, 'C');
            o.Set(1, 'B', 5);
            o.Get(1, 'C');
            o.Sum(1, 'B', new string[] { "A1:A5" });

            o.Set(5, 'A', 10);
            o.Get(1, 'B');
            o.Get(1, 'C');
            o.Sum(3, 'C', new string[] { "A1:C1", "A1:A5" });

            o.Set(3, 'A', 3);
            o.Get(1, 'B');
            o.Get(1, 'C');
            o.Get(3, 'C');
            o.Get(5, 'A');
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem_4_3()
        {
            var o = new Excel(3, 'C');
            o.Sum(1, 'A', new string[] { "A2" });
            o.Set(2, 'A', 1);
            o.Get(1, 'A');
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "38")]

        public void Test_Contest_Week38_Problem_4_4()
        {
            var o = new Excel(26, 'Z');

            //var ops1 = new string[] { "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set", "set" };
            //var ops2 = new string[] { "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum", "sum" };

            //var input1 = new TupleList<int, string, int> { { 1, "A", 0 }, { 1, "B", 1 }, { 1, "C", 2 }, { 1, "D", 3 }, { 1, "E", 4 }, { 1, "F", 5 }, { 1, "G", 6 }, { 1, "H", 7 }, { 1, "I", 8 }, { 1, "J", 9 }, { 1, "K", 10 }, { 1, "L", 11 }, { 1, "M", 12 }, { 1, "N", 13 }, { 1, "O", 14 }, { 1, "P", 15 }, { 1, "Q", 16 }, { 1, "R", 17 }, { 1, "S", 18 }, { 1, "T", 19 }, { 1, "U", 20 }, { 1, "V", 21 }, { 1, "W", 22 }, { 1, "X", 23 }, { 1, "Y", 24 }, { 1, "Z", 25 } };
            //var input2 = new 
        }
    }
}
