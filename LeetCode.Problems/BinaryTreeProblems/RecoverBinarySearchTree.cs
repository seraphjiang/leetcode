using LeetCode.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BinaryTreeProblems
{
    public class RecoverBinarySearchTree
    {
        public void RecoverTree(TreeNode root)
        {
            var list = new List<TreeNode>();
            if (root == null || (root.left == null && root.right == null)) return;
            Inorder(root, list);
            TreeNode first = null;
            TreeNode second = null;
            for (var i = 0; i < list.Count; ++i)
            {

                if (i == 0 && list[i].val > list[i + 1].val)
                {
                    first = first ?? list[i];
                }
                else if (i > 0 && i < list.Count - 1 && list[i].val > list[i - 1].val && list[i].val > list[i + 1].val)
                {
                    first = first ?? list[i];
                }
                else if (i == list.Count - 1 && list[i].val < list[i - 1].val)
                {
                    second = list[i];
                }
                else if (i > 0 && i < list.Count - 1 && list[i].val < list[i - 1].val && list[i].val < list[i + 1].val)
                {
                    second = list[i];
                }
            }

            var temp = first.val;
            first.val = second.val;
            second.val = temp;
        }

        void Inorder(TreeNode root, List<TreeNode> targets)
        {

            if (root.left != null)
            {
                Inorder(root.left, targets);
            }

            targets.Add(root);

            if (root.right != null)
            {
                Inorder(root.right, targets);
            }
        }
    }
}
