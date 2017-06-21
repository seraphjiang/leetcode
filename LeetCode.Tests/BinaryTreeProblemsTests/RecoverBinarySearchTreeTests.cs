using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BinaryTreeProblems;
using LeetCode.DataStructure;
using LeetCode.DataStructure.Standalone.BinaryTrees;

namespace LeetCode.Tests.BinaryTreeProblemsTests
{
    [TestClass]
    public class RecoverBinarySearchTreeTests
    {
        [TestMethod]
        public void Test_RecoverBinarySearchTree_1()
        {
            var tn = new TreeNode(2);
            tn.left = new TreeNode(3);
            tn.right = new TreeNode(1);
            var o = new RecoverBinarySearchTree();
            o.RecoverTree(tn);

        }
        [TestMethod]
        public void Test_RecoverBinarySearchTree_2()
        {
            var tn = new TreeNode(3);
            tn.left = new TreeNode(1);
            tn.right = new TreeNode(2);
            var o = new RecoverBinarySearchTree();
            o.RecoverTree(tn);

        }
        [TestMethod]
        public void Test_RecoverBinarySearchTree_3()
        {
            var bt = new BinaryTree();
            var tn = bt.deserialize("146,71,-13,55,#,231,399,321,#,#,#,#,#,-33");
            var o = new RecoverBinarySearchTree();
            o.RecoverTree(tn);
            var act = bt.serialize(tn);
            Assert.AreEqual("146,71,321,55,#,231,399,-13,#,#,#,#,#,-33", act);
        }
    }
}
