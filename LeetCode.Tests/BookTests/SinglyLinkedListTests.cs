using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Book.Examples;

namespace LeetCode.Tests.BookTests
{
    /// <summary>
    /// http://www.lintcode.com/en/problem/swap-two-nodes-in-linked-list
    /// </summary>
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void Test_SinglyLinkedList_Swap_1()
        {
            var o = new SinglyLinkedList();
            var head = o.Initialize(new[] { 10, 8, 7, 6, 4, 3 });
            var n1 = o.GetByIndex(head, 0);
            var n2 = o.GetByIndex(head, 1);
            var act = o.Swap(head, n1, n2);
            var exp = o.Initialize(new[] { 8, 10, 7, 6, 4, 3 });
            Assert.IsTrue(exp.Equals(act));
        }
    }
}
