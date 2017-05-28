using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.DataStructure.LeetCodeDataStructures;
namespace LeetCode.Problems.ListNodeProblems
{
    public class MergeKSortedLists
    {
        /// <summary>
        /// O(n*lg(k))
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists2(ListNode[] lists)
        {
            var pq = new PriorityQueue<ListNode>(32, Comparer<ListNode>.Create((a,b)=> a.val - b.val));
            var dummy = new ListNode(0);
            var tail = dummy;

            foreach(var n in lists)
            {
                if(n!=null)
                    pq.Push(n);
            }

            while (pq.Count > 0)
            {
                tail.next = pq.Pop();
                tail = tail.next;
                if (tail.next != null)
                    pq.Push(tail.next);
            }

            return dummy.next;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            for (var i = 1; i < lists.Length; ++i)
            {
                Merge(lists, i);
            }

            return lists[0];
        }

        public void Merge(ListNode[] lists, int n)
        {
            if (lists[0] == null) { lists[0] = lists[n]; return; }
            if (lists[n] == null) return;
            var fake = new ListNode(0);
            fake.next = lists[0];

            var n1 = fake;
            var n2 = lists[n];
            while (n1.next != null && n2 != null)
            {
                if (n1.next.val > n2.val)
                {
                    var temp = n2.next;
                    n2.next = n1.next;
                    n1.next = n2;

                    n2 = temp;
                }
                else
                {
                    n1 = n1.next;
                }
            }

            if (n2 != null)
            {
                n1.next = n2;
            }

            lists[0] = fake.next;
        }
    }
}
