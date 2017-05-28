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
