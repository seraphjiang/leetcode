using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.Standalone.BinaryTrees
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public string Value;

        public BinaryTreeNode(int v)
        {
            Value = v.ToString();
        }


        public BinaryTreeNode()
        {
        }
    }
}
