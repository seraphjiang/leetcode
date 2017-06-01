using LeetCode.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BinaryTreeProblems
{
    public class BinaryTreeMaximumPathSum
    {
        int max = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            Dfs(root);
            return max;
        }

        public int DfsNotGood(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                max = Math.Max(max, root.val);
                return root.val;
            }

            var l = Dfs(root.left);
            var r = Dfs(root.right);

            var m = (root.left == null || root.right == null) ? (l + r) : Math.Max(l, r); // could be zero or negetive
            max = Math.Max(max, m);
            max = Math.Max(max, m + root.val);
            max = Math.Max(max, root.val);
            max = Math.Max(max, l + r + root.val);

            return Math.Max(root.val, m + root.val);// must include root.
        }

        public int Dfs(TreeNode root)
        {
            if (root == null) return 0;

            var left = Math.Max(0, Dfs(root.left)); // possible left should always large than 0
            var right = Math.Max(0, Dfs(root.right)); // if child is negative , just ignore by return to 0
            max = Math.Max(max, left + right + root.val);
            return Math.Max(left, right) + root.val;
        }

    }
}
