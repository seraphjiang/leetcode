using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.GreedyProblems;
using System.Linq;
namespace LeetCode.Tests.GreedyProblemsTests
{
    [TestClass]
    public class CreateMaximumNumberTests
    {
        [TestMethod]
        [TestProperty("Google", "Greedy")]
        public void Test_CreateMaximumNumber_1()
        {
            var o = new CreateMaximumNumber();
            var act = o.MaxNumber(new int[] { 3, 4, 6, 5 }, new int[] { 9, 1, 2, 5, 8, 3 }, 5);
            Console.WriteLine(string.Join(",", act));
            Assert.IsTrue(act.SequenceEqual(new int[] { 9, 8, 6, 5, 3 }));
        }
        [TestMethod]
        [TestProperty("Google", "Greedy")]
        public void Test_CreateMaximumNumber_2()
        {
            var o = new CreateMaximumNumber();
            var act = o.MaxNumber(new int[] { 8, 6, 9 }, new int[] { 1, 7, 5 }, 3);

            Assert.IsTrue(act.SequenceEqual(new int[] { 9, 7, 5 }));
        }
        [TestMethod]
        [TestProperty("Google", "Greedy")]

        public void Test_CreateMaximumNumber_3()
        {
            var o = new CreateMaximumNumber();
            var act = o.MaxNumber(new int[] { 7, 6, 1, 9, 3, 2, 3, 1, 1 }, new int[] { 4, 0, 9, 9, 0, 5, 5, 4, 7 }, 9);
            Console.WriteLine(string.Join(",", act));
            Assert.IsTrue(act.SequenceEqual(new int[] { 9, 9, 9, 7, 3, 2, 3, 1, 1 }));
        }
        [TestMethod]
        [TestProperty("Google", "Greedy")]

        public void Test_CreateMaximumNumber_4()
        {
            var o = new CreateMaximumNumber();
            var act = o.MaxNumber(new int[] { 8, 9 }, new int[] { 3, 9 }, 3);

            Assert.IsTrue(act.SequenceEqual(new int[] { 9, 8, 9 }));
        }
    }
}
