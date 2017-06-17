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
    }
}
