using LeetCode.DataStructure.LeetCodeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ListNodeProblems
{
    public class ReverseNodesinkGroup
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k < 2) return head;

            var dummy = new ListNode(0);
            dummy.next = head;

            var node = head;
            var preDummy = dummy;
            var pre = dummy;
            while (node != null)
            {
                // check if rest is large or equals k
                var p = node;
                var j = 0;
                while (p != null)
                {
                    p = p.next;
                    j++;
                    if (j == k) break;
                }

                if (j < k) return dummy.next;

                while (node != null && j > 0)
                {
                    if (node == preDummy.next)
                    {
                        pre = node;
                        node = node.next;
                    }
                    else
                    {
                        var next = node.next;
                        node.next = preDummy.next;
                        preDummy.next = node;
                        pre.next = next;
                        node = next;
                    }
                    j--;
                }

                preDummy = pre;
            }


            return dummy.next;
        }

        public ListNode reverseKGroup1(ListNode head, int k)
        {
            int n = 0;
            for (ListNode i = head; i != null; n++, i = i.next) ;

            ListNode dmy = new ListNode(0);
            dmy.next = head;
            for (ListNode prev = dmy, tail = head; n >= k; n -= k)
            {
                for (int i = 1; i < k; i++)
                {
                    ListNode next = tail.next.next;
                    tail.next.next = prev.next;
                    prev.next = tail.next;
                    tail.next = next;
                }

                prev = tail;
                tail = tail.next;
            }
            return dmy.next;
        }

        public ListNode reverseKGroup2(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            { // find the k+1 node
                curr = curr.next;
                count++;
            }
            if (count == k)
            { // if k+1 node is found
                curr = reverseKGroup2(curr, k); // reverse list with k+1 node as head
                                               // head - head-pointer to direct part, 
                                               // curr - head-pointer to reversed part;
                while (count-- > 0)
                { // reverse current k-group: 
                    ListNode tmp = head.next; // tmp - next head in direct part
                    head.next = curr; // preappending "direct" head to the reversed list 
                    curr = head; // move head of reversed part to a new node
                    head = tmp; // move "direct" head to the next node in direct part
                }
                head = curr;
            }
            return head;
        }
    }
}
