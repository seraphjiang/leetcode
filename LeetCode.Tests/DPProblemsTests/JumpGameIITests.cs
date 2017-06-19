using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DynamicProgrammingProblems;

namespace LeetCode.Tests.DPProblemsTests
{
    [TestClass]
    public class JumpGameIITests
    {
        [TestMethod]
        public void Test_JumpGameII_1()
        {
            var o = new JumpGameII();
            Assert.AreEqual(2, o.Jump(new int[] { 1, 2, 3 }));
        }
        [TestMethod]
        public void Test_JumpGameII_2()
        {
            var o = new JumpGameII();
            Assert.AreEqual(0, o.Jump(new int[] { 1 }));
        }
        [TestMethod]
        public void Test_JumpGameII_3()
        {
            var o = new JumpGameII();
            Assert.AreEqual(1, o.Jump(new int[] { 1, 2 }));
        }
        [TestMethod]
        public void Test_JumpGameII_4()
        {
            var o = new JumpGameII();
            Assert.AreEqual(2, o.Jump(new int[] { 7, 0, 9, 6, 9, 6, 1, 7, 9, 0, 1, 2, 9, 0, 3 }));
        }
        [TestMethod]
        public void Test_JumpGameII_5()
        {
            var o = new JumpGameII();
            Assert.AreEqual(3, o.Jump(new int[] { 1, 2, 1, 1, 1 }));
        }
        [TestMethod]
        public void Test_JumpGameII_6()
        {
            var o = new JumpGameII();
            Assert.AreEqual(4, o.Jump(new int[] { 6, 2, 6, 1, 7, 9, 3, 5, 3, 7, 2, 8, 9, 4, 7, 7, 2, 2, 8, 4, 6, 6, 1, 3 }));
        }
    }
}
