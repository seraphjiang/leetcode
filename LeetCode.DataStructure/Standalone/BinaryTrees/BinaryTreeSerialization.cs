using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.Standalone.BinaryTrees
{
    public class BinaryTreeSerialization
    {
        public static string SampleTreeString = "30,10,50,#,#,#,20,45,#,#,35,#,#";
        public static BinaryTreeNode SampleTree;

        //tree
        //http://leetcode.com/2010/09/serializationdeserialization-of-binary.html
        //        30
        //        /\
        //      10  20
        //      /   /\
        //    50   45 35
        // pre-order  "30,10,50,#,#,#,20,45,#,#,35,#,#"
        private static void Main(string[] args)
        {
            string input = "30,10,50,#,#,#,20,45,#,#,35,#,#";
            string[] tokens = input.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var root = new BinaryTreeNode(30)
            {
                Left = new BinaryTreeNode(10)
                {
                    Left = new BinaryTreeNode(50)
                },
                Right = new BinaryTreeNode(20)
                {
                    Left = new BinaryTreeNode(45),
                    Right = new BinaryTreeNode(35)
                }
            };

            //Serliaze
            Console.WriteLine(Serialize(root));

            //Deserlizae
            BinaryTreeNode node1 = Deserialize(tokens.ToList());

            BinaryTreeNode node2 = Deserialize2(tokens.ToList());
        }

        public static string Serialize(BinaryTreeNode root)
        {
            var stack = new Stack<string>();
            WriteInOrder(root, stack);
            List<string> queue = stack.ToList();
            queue.Reverse();
            string result = queue.Aggregate((current, next) => current + "," + next);
            return result;
        }


        private static void WriteInOrder(BinaryTreeNode root, Stack<string> stack)
        {
            if (root == null)
            {
                stack.Push("#");
                return;
            }
            stack.Push(root.Value);
            WriteInOrder(root.Left, stack);
            WriteInOrder(root.Right, stack);
        }

        public static BinaryTreeNode Deserialize(List<string> list)
        {
            list.Reverse();
            var stack = new Stack<string>(list);

            var root = new BinaryTreeNode(int.Parse(stack.Pop()));
            ReadInOrder(root, true, stack);
            ReadInOrder(root, false, stack);
            return root;
        }

        public static BinaryTreeNode Deserialize2(List<string> list)
        {
            list.Reverse();
            var stack = new Stack<string>(list);

            var root = new BinaryTreeNode(int.Parse(stack.Pop()));
            ReadInOrder2(root.Left, stack);
            ReadInOrder2(root.Right, stack);
            return root;
        }

        private static void ReadInOrder(BinaryTreeNode root, bool left, Stack<string> stack)
        {
            string token = stack.Pop();
            if (token == null)
                return;
            if (token != "#")
            {
                var node = new BinaryTreeNode(int.Parse(token));
                if (left)
                {
                    root.Left = node;
                }
                else
                {
                    root.Right = node;
                }
                ReadInOrder(node, true, stack);
                ReadInOrder(node, false, stack);
            }
        }


        private static void ReadInOrder2(BinaryTreeNode root, Stack<string> stack)
        {
            string token = stack.Pop();
            if (token == null)
                return;
            if (token != "#")
            {
                root = new BinaryTreeNode(int.Parse(token));
                ReadInOrder2(root.Left, stack);
                ReadInOrder2(root.Right, stack);
            }
        }
    }
}
