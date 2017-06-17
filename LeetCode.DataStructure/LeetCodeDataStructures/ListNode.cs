using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.LeetCodeDataStructures
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override bool Equals(object obj)
        {
            var a = this;
            var b = obj as ListNode;

            var x = a;
            var y = b;

            while (x != null && y != null)
            {
                if (x.val != y.val) return false;
                x = x.next;
                y = y.next;
            }

            return x == null && y == null;
        }

        public ListNode Clone()
        {
            var ret = new ListNode(this.val);
            var node = ret;
            var node2 = this;
            while (node2.next != null)
            {
                node.next = new ListNode(node2.next.val);
                node2 = node2.next;
                node = node.next;
            }

            return ret;
        }
    }
}
