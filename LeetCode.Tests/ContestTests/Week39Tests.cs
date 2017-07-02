﻿using System;
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
            var o = new SumOfSquareNumber();
            var exp = 1;
            //var act = o.JudgeSquareSum(2147482647);
            var act = o.JudgeSquareSum(2147483645);

            
            //Assert.AreEqual(exp, exp);
        }

        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem2()
        {
            var o = new LogSystem();
            o.Put(1, "2017:01:01:23:59:59");
            o.Put(2, "2017:01:01:22:59:59");
            o.Put(3, "2016:01:01:00:00:00");
            //o.Put(4, "2016:01:01:01:01:01");
            //o.Put(5, "2017:01:01:23:00:00");
            o.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Year");
            //o.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Hour");
        }
        [TestMethod]
        [TestProperty("WeeklyContest", "39")]

        public void Test_Contest_Week39_Problem2_1()
        {
            var o = new LogSystem();

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
