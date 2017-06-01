using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BinaryTreeProblems;
using LeetCode.DataStructure.Standalone.BinaryTrees;

namespace LeetCode.Tests.BinaryTreeProblemsTests
{
    [TestClass]
    public class BinaryTreeMaximumPathSumTests
    {
        [TestMethod]
        public void Test_BinaryTreeMaximumPathSum1()
        {
            var tn = (new BinaryTree()).deserialize("1,-2,-3,1,3,-2,#,-1");
            var o = new BinaryTreeMaximumPathSum();
            Assert.AreEqual(3, o.MaxPathSum(tn));
        }
        [TestMethod]
        public void Test_BinaryTreeMaximumPathSum2()
        {
            var tn = (new BinaryTree()).deserialize("-1,5,#,4,#,#,2,-4");
            var o = new BinaryTreeMaximumPathSum();
            Assert.AreEqual(11, o.MaxPathSum(tn));
        }
    }
}
