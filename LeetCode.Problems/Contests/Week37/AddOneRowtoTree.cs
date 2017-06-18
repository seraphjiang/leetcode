using LeetCode.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week37
{
    public class AddOneRowtoTree
    {
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (root == null || d < 1) return root;
            if (d == 1)
            {
                var newRoot = new TreeNode(v);
                newRoot.left = root;
                return newRoot;
            }

            var level = 2;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var count = q.Count;
                for (var i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    if (level == d)
                    {
                        var left = node.left;
                        var right = node.right;

                        node.left = new TreeNode(v);
                        node.right = new TreeNode(v);
                        node.left.left = left;
                        node.right.right = right;
                    }
                    else if (level < d)
                    {
                        if (node.left != null) q.Enqueue(node.left);
                        if (node.right != null) q.Enqueue(node.right);
                    }
                }

                if (level == d) break;
                level++;
            }


            return root;
        }
    }
}
