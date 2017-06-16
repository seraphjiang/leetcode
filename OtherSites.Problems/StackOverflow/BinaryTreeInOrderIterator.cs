using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSites.Problems.StackOverflow
{

    public class TreeIterator
    {
        public class Node
        {
            public Node left;
            public Node right;
            public Node parent;
        }
        private Node next;

        public TreeIterator(Node root)
        {
            next = root;
            if (next == null)
                return;

            while (next.left != null)
                next = next.left;
        }

        public bool hasNext()
        {
            return next != null;
        }

        public Node Next()
        {
            if (!hasNext()) throw new InvalidOperationException();
            Node r = next;

            // If you can walk right, walk right, then fully left.
            // otherwise, walk up until you come from left.
            if (next.right != null)     //  this is case , most left node has right children.
            {                           
                next = next.right;
                while (next.left != null)
                    next = next.left;
                return r;
            }

            while (true)
            {
                if (next.parent == null)    // node no right children, and parent is null, this is root
                {
                    next = null;
                    return r;
                }
                if (next.parent.left == next)
                {
                    next = next.parent; // for all left parent, has already been visitied
                    return r;
                }
                next = next.parent;
            }
        }
    }

}
