using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week35
{
    public class ConstructStringfromBinaryTree
    {
        public string Tree2str(TreeNode t)
        {
            if (t == null) return "";
            return Dfs(t);
        }

        public string Dfs(TreeNode t)
        {
            var sb = new StringBuilder();
            sb.Append(t.val);
            if (t.left != null)
            {
                sb.Append('(');
                sb.Append(Dfs(t.left));
                sb.Append(')');
            }
            if (t.right != null)
            {
                if (t.left == null)
                {
                    sb.Append("()");
                }

                sb.Append('(');
                sb.Append(Dfs(t.right));
                sb.Append(')');
            }

            return sb.ToString();
        }
    }
}
