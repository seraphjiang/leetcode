using LeetCode.DataStructure.LeetCodeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Book.Examples
{
    public class SinglyLinkedList
    {
        public ListNode Initialize(int[] arr)
        {
            var dummy = new ListNode(0);
            var node = dummy;
            for (var i = 0; i < arr.Length; i++)
            {
                node.next = new ListNode(arr[i]);
                node = node.next;
            }

            return dummy.next;
        }

        public int GetLength(ListNode head)
        {
            var node = head; // we use node to traversal the lined list
            var count = 0;
            while (node != null) { node = node.next; count++; }
            return count;
        }

        public ListNode GetTail(ListNode head)
        {
            var node = head;
            while (node != null && node.next != null) node = node.next;
            // after while loop, we either get a tail node or null if tail doesn't exist(head is null)

            return node;
        }

        public ListNode GetByIndex(ListNode head, int index)
        {
            if (head == null || index < 0) return null;
            // index is zero based, from 0...
            var node = head;
            while (index-- > 0 && node != null)
            {
                node = node.next;
            }
            // return null if index >= length;
            return node;
        }

        public void Update(ListNode head, int index, int val)
        {
            var node = GetByIndex(head, index);
            if (node != null) node.val = val;
        }

        public void Replace(ListNode head, int index, ListNode n2)
        {
            if (head == null || index < 0) return;

            if (index == 0)
            {
                if (n2 == null) return; // invalid operation, even we assign null to head, it worn't change original head
                head.val = n2.val;
                head.next = n2.next;
                return;
            }

            var pre = GetByIndex(head, index - 1);
            pre.next = n2; // all nodes in previous linked list after pre, will be abandoned.
        }

        // just swap the val, no need to use head to locate node
        public void Swap(ListNode n1, ListNode n2)
        {
            if (n1 == null || n2 == null) return;
            var t = n1.val;
            n1.val = n2.val;
            n2.val = t;
        }

        // do actual swap the node, need to use head to locate the node
        public ListNode Swap(ListNode head, ListNode n1, ListNode n2)
        {
            if (n1 == null || n2 == null || n1 == n2) return head;
            if (n2.next == n1) return Swap(head, n2, n1);
            var dummy = new ListNode(0);
            dummy.next = head;
            var pre1 = GetPrevious(head, n1) ?? dummy;
            var pre2 = GetPrevious(head, n2) ?? dummy;

            var next = n2.next;
            if(n1.next == n2) // handle 10->8->6->5  swap 10, 8 node
            {
                pre1.next = n2;
                // n2.next = n1.next;  this just create a cycle
                n2.next = n1;
                //pre2.next = n1;  this just create another cycle
                n1.next = next; //n2.next;
            }
            else
            {
                pre1.next = n2;
                n2.next = n1.next;
                pre2.next = n1;
                n1.next = next; //n2.next;
            }

            return dummy.next;
        }

        public ListNode GetPrevious(ListNode head, ListNode node)
        {
            if (head == node) return null;
            var n = head;
            while (n != null)
            {
                if (n.next == node) return n;
                n = n.next;
            }

            return null;
        }
    }
}
