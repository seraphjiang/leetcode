using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ListNodeProblems;
using LeetCode.DataStructure.LeetCodeDataStructures;

namespace LeetCode.Tests.ListNodeProblemsTests
{
    [TestClass]
    public class ReverseNodesinkGroupTests
    {
        [TestMethod]
        public void Test_ReverseNodesinkGroup1()
        {
            var o = new ReverseNodesinkGroup();
            var ln = new ListNode(1);
            ln.next = new ListNode(2);

            var exp = new ListNode(2);
            exp.next = new ListNode(1);
            Assert.AreEqual(exp, o.ReverseKGroup(ln, 2));

        }
        [TestMethod]
        public void Test_ReverseNodesinkGroup2()
        {
            var o = new ReverseNodesinkGroup();
            var ln = new ListNode(1);
            ln.next = new ListNode(2);

            var exp = ln.Clone();
            
            Assert.AreEqual(exp, o.ReverseKGroup(ln, 3));

        }

        [TestMethod]
        public void Test_ReverseNodesinkGroup3()
        {
            var o = new ReverseNodesinkGroup();
            var ln = new ListNode(1);
            ln.next = new ListNode(2);
            ln.next.next = new ListNode(3);

            var exp = new ListNode(2);
            exp.next = new ListNode(1);
            exp.next.next = new ListNode(3);

            Assert.AreEqual(exp, o.ReverseKGroup(ln, 2));

        }
    }
}
