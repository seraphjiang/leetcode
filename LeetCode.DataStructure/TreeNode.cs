using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public override bool Equals(object obj)
        {
            var target = obj as TreeNode;

            return Equals(this, target);
        }

        private bool Equals(TreeNode a, TreeNode b)
        {
            if (a == null || b == null) return a == null && b == null;
            if (a.val != b.val) return false;
            return Equals(a.left, b.left) && Equals(a.right, b.right);
        }

    }
}
