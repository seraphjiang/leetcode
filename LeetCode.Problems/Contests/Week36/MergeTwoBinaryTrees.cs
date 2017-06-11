using LeetCode.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week36
{
    /// <summary>
    /// 617. Merge Two Binary Trees My SubmissionsBack To Contest
    /// </summary>
    public class MergeTwoBinaryTrees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            var root = new TreeNode(t1.val + t2.val);
            root.left = MergeTrees(t1.left, t2.left);
            root.right = MergeTrees(t1.right, t2.right);
            return root;
        }
    }
}
