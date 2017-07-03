using LeetCode.DataStructure.LeetCodeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ListNodeProblems
{
    public class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            if (fast != null)
            {
                slow = slow.next;
            }

            slow = Reverse(slow);

            while (head != null && slow != null)
            {
                if (head.val != slow.val)
                {
                    return false;
                }
                head = head.next;
                slow = slow.next;
            }

            return true;
        }

        public ListNode Reverse(ListNode head)
        {
            ListNode pre = null;
            ListNode next;
            while (head != null)
            {
                next = head.next;
                head.next = pre;
                pre = head;
                head = next;
            }

            return pre;
        }
        public bool IsPalindromeRecursive(ListNode head)
        {
            return head == null || recurse(head, head) != null;
        }

        private ListNode recurse(ListNode node, ListNode head)
        {
            if (node == null) return head; // exit recusion when reach end of tail
            ListNode res = recurse(node.next, head); // in recusion, node iterate from tail to head, res from head to tail.
            if (res == null) return res;
            else if (res.val == node.val) return (res.next == null ? res : res.next);   // return compare node(cur from tail) to head
            else return null;
        }
    }
}