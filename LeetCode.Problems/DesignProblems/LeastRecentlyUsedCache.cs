using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LeetCode.Problems.DesignProblems
{
    /// <summary>
    /// Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
    ///key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    ///put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
    ///Follow up:
    ///Could you do both operations in O(1) time complexity?
    /// </summary>
    public class LRUCache
    {
        public int Capacity { get; set; }
        LinkedList<Node> dl = new LinkedList<Node>();

        Dictionary<int, LinkedListNode<Node>> cache = new Dictionary<int, LinkedListNode<Node>>();
        public LRUCache(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key)) return -1;
            // Move node to last of linked list;
            var val = cache[key].Value;

            dl.Remove(val);

            cache[key] = dl.AddLast(new Node(key, val.Value));
            
            return val.Value;
        }

        public void Put(int key, int value)
        {
            if (!cache.ContainsKey(key) && dl.Count == Capacity)
            {
                var node = dl.First.Value as Node;
                cache.Remove(node.Key);
                dl.RemoveFirst();
            }
            if (cache.ContainsKey(key))
            { 
                dl.Remove(cache[key]);
            }
            // Add to last node. and cache it in cache.
            cache[key] = dl.AddLast(new Node(key, value));
        }
    }

    public class Node
    {
        public Node(int key, int val)
        {
            Key = key;
            Value = val;
        }
        public int Value;
        public int Key;
    }
}
