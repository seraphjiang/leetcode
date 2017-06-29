using LeetCode.DataStructure.LeetCodeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ListNodeProblems
{
    public class ReverseLinkedList
    {
        /// <summary>
        /// 1. use dummy to better handle empty head problem
        /// 2. return null if head is null
        /// 3. tail point to orignal head, and tail.next will always point to next, otherwize will infinite loop
        /// 4. cur init as head.next. not head. because if there is only one node, then we don't need to reverse
        /// 5. in while loop
        /// 5.1 store next point
        /// 5.2 point current.next to pre head, which is dummy.next
        /// 5.3. now we can point head to current, dummy.next = current
        /// 5.4 afer above, move cur to next node which need to process
        /// 5.5 move tail.next to next //without this line, a linked list 1,2,3,4 will become 4,3,2,1 (2,1,2,1...) inifinity loop
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;
            var dummy = new ListNode(0);
            dummy.next = head;

            var tail = head;
            var cur = head.next;

            while (cur != null)
            {
                var next = cur.next;
                cur.next = dummy.next;
                dummy.next = cur;
                tail.next = next; // without this line, a linked list 1,2,3,4 will become 4,3,2,1 (2,1,2,1...) inifinity loop
                cur = next;

            }

            return dummy.next;
        }
    }
}
