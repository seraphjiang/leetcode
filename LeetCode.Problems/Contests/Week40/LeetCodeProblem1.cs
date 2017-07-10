using LeetCode.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week40
{
    public class LeetCodeProblem1
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var res = new List<double>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var count = q.Count;
                double total = 0;
                for (var i = 0; i < count; i++)
                {
                    TreeNode node = q.Dequeue();
                    total += node.val;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                res.Add(total / count);
            }

            return res;
        }
    }
}
