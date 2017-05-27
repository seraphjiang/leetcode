using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.Standalone.BinaryTrees
{
    public class BinaryTree
    {
        public void Ping() { }
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "#";
            var q = new Queue<TreeNode>();
            var list = new List<string>();
            var nullNodesHolder = new List<string>();

            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                for (var i = 0; i < count; ++i)
                {
                    var node = q.Dequeue();
                    if (node == null)
                    {
                        nullNodesHolder.Add("#");
                    }
                    else
                    {
                        list.AddRange(nullNodesHolder);
                        nullNodesHolder = new List<string>();
                        list.Add(node.val.ToString());
                        q.Enqueue(node.left);
                        q.Enqueue(node.right);
                    }
                }

            }
            var ret = string.Join(",", list);
            Console.WriteLine(ret);
            return ret;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data) || data == "#") return null;
            var list = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var q = new Queue<TreeNode>();
            var root = new TreeNode(int.Parse(list[0]));
            q.Enqueue(root);
            for (var i = 1; i < list.Length; i += 2)
            {
                var node = q.Dequeue();
                Console.WriteLine("i:{0},node:{1}", i, node.val);
                if (list[i] != "#")
                {
                    node.left = new TreeNode(int.Parse(list[i]));
                    q.Enqueue(node.left);
                }

                if (i + 1 < list.Length && list[i + 1] != "#")
                {
                    node.right = new TreeNode(int.Parse(list[i + 1]));
                    q.Enqueue(node.right);
                }

            }
            return root;
        }
    }
}
