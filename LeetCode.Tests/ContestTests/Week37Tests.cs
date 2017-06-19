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
            var o = new AddOneRowtoTree();

        }
        [TestMethod]
        public void TestMethod3()
        {
            var o = new MinimumFactorization();

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
        [TestMethod]
        public void Test_TaskSchedulerProblem_5()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAAAABBBBBCCCC".ToCharArray();
            var a = o.LeastInterval(input, 2);
            Assert.AreEqual(14, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_6()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAAAABBBBBCCCCCDDDD".ToCharArray();
            var a = o.LeastInterval(input, 2);
            Assert.AreEqual(14, a);
        }

        [TestMethod]
        public void Test_TaskSchedulerProblem_7()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAABBBCCCDD".ToCharArray();
            var a = o.LeastInterval(input, 1);
            Assert.AreEqual(11, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_8()
        {
            var o = new TaskSchedulerProblem();
            var input = "AABCD".ToCharArray();
            var a = o.LeastInterval(input, 1);
            Assert.AreEqual(5, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_9()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAAAA".ToCharArray();
            var a = o.LeastInterval(input, 1);
            Assert.AreEqual(9, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_10()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAAAAAA".ToCharArray();
            var a = o.LeastInterval(input, 1);
            Assert.AreEqual(13, a);
        }
        [TestMethod]
        public void Test_TaskSchedulerProblem_11()
        {
            var o = new TaskSchedulerProblem();
            var input = "AAAAABBBB".ToCharArray();
            var a = o.LeastInterval(input, 1);
            Assert.AreEqual(9, a);
        }
    }
}
