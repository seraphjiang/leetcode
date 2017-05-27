using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.DataStructure.Standalone.BinaryTrees;
using System.Diagnostics;

namespace LeetCode.DataStructure.Tests.BinaryTreeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var root = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                },
                Right = new BinaryTreeNode(3)
                {
                    Left = new BinaryTreeNode(4),
                    Right = new BinaryTreeNode(5)
                }
            };

            var res = BinaryTreeSerialization.Serialize(root);
            Debug.Print(res);
        }

        [TestMethod]
        public void TestMethod2()
        {

            var root = new TreeLinkNode(1)
            {
                left = new TreeLinkNode(2)
                {
                },
                right = new TreeLinkNode(3)
                {
                    left = new TreeLinkNode(4),
                    right = new TreeLinkNode(5)
                }
            };
            var res = TreeLinkNode.Serialize(root);
            Debug.Print(res);

        }
        [TestMethod]
        public void TestMethod3()
        {
            var bt = new BinaryTree();
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                }
            };
            var res = bt.serialize(root);
            Debug.Print(res);
            Assert.AreEqual("1,2,3,#,#,4,5", res);
        }

        /// <summary>
        /// [1,3,null,null,4]
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var bt = new BinaryTree();
            var root = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    right = new TreeNode(4)
                },

            };
            var res = bt.serialize(root);
            Debug.Print(res);
            Assert.AreEqual("1,3,#,#,4", res);
        }

        /// <summary>
        /// 5,2,3,null,null,2,4,3,1
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
        }
    }
}