using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.Contests.Week37;

namespace LeetCode.Tests.ContestTests
{
    [TestClass]
    public class Week37Tests
    {
        [TestMethod]
        public void Test_MaximumDistanceinArrays_1()
        {
            IList<IList<int>> input = new List<IList<int>>()
            {
                new List<int>{ 1,2,3},
                new List<int>{4,5 },
                new List<int>{1,2,3 }
            };
            var o = new MaximumDistanceinArrays();
            var ret = o.MaxDistance(input);
            Assert.AreEqual(4, ret);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var o = new Class2();

        }
        [TestMethod]
        public void TestMethod3()
        {
            var o = new Class3();

        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_1()
        {
            var o = new TaskSchedulerProblem();
            var input = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            var a = o.LeastInterval(input, 2);
            Assert.AreEqual(8, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_2()
        {
            var o = new TaskSchedulerProblem();
            var input = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            var a = o.LeastInterval(input, 0);
            Assert.AreEqual(6, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_3()
        {
            var o = new TaskSchedulerProblem();
            var input = new char[] { 'A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E' };
            var a = o.LeastInterval(input, 4);
            Assert.AreEqual(10, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_4()
        {
            var o = new TaskSchedulerProblem();
            var input = new char[] { 'A', 'B', 'C', 'A', 'B' };
            var a = o.LeastInterval(input, 2);
            Assert.AreEqual(5, a);
        }

    }
}
