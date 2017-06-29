using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ListNodeProblems;
using LeetCode.DataStructure.LeetCodeDataStructures;

namespace LeetCode.Tests.ListNodeProblemsTests
{
    [TestClass]
    public class ReverseLinkedListTests
    {
        [TestMethod]
        public void Test_ReverseLinkedList_1()
        {
            var node = new ListNode(1);
            node.next = new ListNode(2);
            node.next.next = new ListNode(3);

            var o = new ReverseLinkedList();
            var act = o.ReverseList(node);
        }
    }
}
