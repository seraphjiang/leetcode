using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.Standalone.BinaryTrees
{
    public class TreeLinkNode
    {
        public TreeLinkNode next;

        public TreeLinkNode()
        {
        }

        public TreeLinkNode(int x)
        {
            val = x;
        }

        public int val { get; set; }
        public TreeLinkNode left { get; set; }
        public TreeLinkNode right { get; set; }


        public static string Serialize(TreeLinkNode root)
        {
            var list = new List<string>();

            // level traversal
            TreeLinkNode levelHead = root;

            while (levelHead != null)
            {
                TreeLinkNode levelElement = levelHead;
                TreeLinkNode firstChild = null;
                while (levelElement != null)
                {
                    if (firstChild == null)
                    {
                        if (levelElement.left != null)
                        {
                            firstChild = levelElement.left;
                        }
                        else if (levelElement.right != null)
                        {
                            firstChild = levelElement.right;
                        }
                    }

                    list.Add(levelElement.val.ToString());
                    levelElement = levelElement.next;
                }

                list.Add("#");

                levelHead = firstChild;
            }


            return string.Join(",", list);
        }

        public static TreeLinkNode Deserialize(string serial)
        {
            IEnumerator<string> enumerator =
                serial.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).AsEnumerable().GetEnumerator();

            TreeLinkNode root = null;

            if (enumerator.MoveNext() && enumerator.Current != "#")
            {
                root = new TreeLinkNode(int.Parse(enumerator.Current));
            }
            else
            {
                return null;
            }

            var levelBreak = new TreeLinkNode(0);
            var queue = new Queue<TreeLinkNode>();
            queue.Enqueue(root);
            queue.Enqueue(levelBreak);

            while (enumerator.MoveNext())
            {
                TreeLinkNode node = queue.Dequeue();

                if (queue.Peek() == levelBreak)
                {
                    // ignore next token
                    if (!enumerator.MoveNext())
                        break;
                }

                // add last two children;
                node.left = CreateNewNode(enumerator.Current);
                queue.Enqueue(node.left);

                if (enumerator.MoveNext())
                {
                    node.right = CreateNewNode(enumerator.Current);
                    queue.Enqueue(node.right);
                }
                else
                {
                    break;
                }


                if (queue.Peek() == levelBreak)
                {
                    // add new linebreak;
                    queue.Enqueue(levelBreak);

                    // remove current linebreak;
                    queue.Dequeue();
                }
            }

            return root;
        }

        public static TreeLinkNode CreateNewNode(string val)
        {
            if (val == "#")
            {
                return null;
            }
            return new TreeLinkNode(int.Parse(val));
        }

        public static TreeLinkNode DeserializeWithoutNext(string serial)
        {
            TreeLinkNode root = null;
            string[] elements = serial.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (elements == null || (elements.Length == 1 && elements[0] == "#"))
            {
                return null;
            }
            IEnumerator<string> enumerator = elements.AsEnumerable().GetEnumerator();
            enumerator.MoveNext();

            root = new TreeLinkNode(int.Parse(enumerator.Current));
            Read(root, true, enumerator);
            Read(root, false, enumerator);

            return root;
        }


        private static void Read(TreeLinkNode parent, bool isLeft, IEnumerator<string> enumerator)
        {
            if (parent == null || !enumerator.MoveNext() || enumerator.Current == "#")
                return;
            string current = enumerator.Current;

            var node = new TreeLinkNode(int.Parse(current));
            if (isLeft)
            {
                parent.left = node;
            }
            else
            {
                parent.right = node;
            }

            Read(node, true, enumerator);
            Read(node, false, enumerator);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var p = obj as TreeLinkNode;
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return val == p.val
                   && (left == p.left || left.Equals(p.left))
                   && (right == p.left || right.Equals(p.right));
        }
    }
}
