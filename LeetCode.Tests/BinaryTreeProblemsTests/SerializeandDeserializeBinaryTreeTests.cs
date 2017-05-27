using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.BinaryTreeProblems;

using LeetCode.DataStructure.Standalone.BinaryTrees;
namespace LeetCode.Tests.BinaryTreeProblemsTests
{
    [TestClass]
    public class SerializeandDeserializeBinaryTreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bt = new SerializeandDeserializeBinaryTree();
            var expect = "1,2,3";
            var tree = bt.deserialize("1,2,3");

            Assert.AreEqual(expect, bt.serialize(tree));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var bt = new SerializeandDeserializeBinaryTree();
            var expect = "1,3,#,#,4";
            var tree = bt.deserialize(expect);

            Assert.AreEqual(expect, bt.serialize(tree));
        }
        [TestMethod]
        public void TestMethod3()
        {
            var bt = new SerializeandDeserializeBinaryTree();
            var expect = "1,2,3,#,#,4,5,6,7";
            var tree = bt.deserialize(expect);

            Assert.AreEqual(expect, bt.serialize(tree));
        }
    }
}
