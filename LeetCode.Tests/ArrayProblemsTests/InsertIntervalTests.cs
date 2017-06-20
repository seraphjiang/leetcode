using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ArrayProblems;
using LeetCode.DataStructure.LeetCodeDataStructures;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tests.ArrayProblemsTests
{
    [TestClass]
    public class InsertIntervalTests
    {
        [TestMethod]
        public void Test_InsertInterval_1()
        {
            var o = new InsertInterval();
            var input = new List<Interval>
            {
                new Interval(1,3),
                new Interval(6,9)
            };

            var exp = new List<Interval>
            {
                new Interval(1,5),
                new Interval(6,9)
            };

            var act = o.Insert(input, new Interval(2, 5));
            Assert.IsTrue(exp.SequenceEqual(act));
        }
    }
}
