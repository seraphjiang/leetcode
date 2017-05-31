using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DesignProblems
{
    /// <summary>
    /// the key to solve this problem without use 3 dict or more other data structure is 
    /// 1. the rule of how min change
    /// 2. how to update count
    /// 
    /// when we get value, we will remove node from freq-list[freq] to freq-list[freq+1]
    ///     therefore, after move, if freq-list[min].count == 0 , that means we moved and empty the least freq used item 
    ///     in this case, min could increase one. because, we just move that item to min+1 list.
    /// 
    /// for a set operation, we always try get it. it will auto increase freq if key exist. we just need to udpate the value. we don't need to worry about excced capacity issue.
    ///     in another case, key doesn't exists. we need to add the item. and set min always to 1; we do need to conside remove expired item. it could be find by 
    ///            freq-list[min].first , remove the cache first, then remove it from freq-list.
    /// </summary>
    public class LFUCache
    {
        public int Capacity;
        public int min = 0;

        Dictionary<int, LinkedListNode<CacheItem>> cache = new Dictionary<int, LinkedListNode<CacheItem>>();
        Dictionary<int, LinkedList<CacheItem>> freqlist = new Dictionary<int, LinkedList<CacheItem>>();
        public LFUCache(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Get(int key)
        {
            if (Capacity <= 0) return -1;
            if (!this.cache.ContainsKey(key)) return -1;

            var item = this.cache[key];
            // remove item from freq list;
            freqlist[item.Value.Count].Remove(item);
            // add item to freq list
            item.Value.Count++;
            if (!freqlist.ContainsKey(item.Value.Count)) {
                freqlist[item.Value.Count] = new LinkedList<CacheItem>();
            }
            freqlist[item.Value.Count].AddLast(item);

            if(freqlist[min].Count == 0)
            {
                min++;
            }
            return item.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (this.Capacity <= 0) return;

            var item = this.Get(key);
            if(item != -1)
            {
                // count already updated
                this.cache[key].Value.Value = value;
                return;
            }

            if(cache.Count == this.Capacity)
            {
                // remove invalid node
                var expired = this.freqlist[min].First;
                this.cache.Remove(expired.Value.Key);
                this.freqlist[min].RemoveFirst();
            }
            //insert
            var newItem = new CacheItem { Key = key, Value = value, Count = 1 };
            if (!this.freqlist.ContainsKey(1)) this.freqlist[1] = new LinkedList<CacheItem>();
            var newNode = this.freqlist[1].AddLast(newItem);
            this.cache.Add(key, newNode);
            min = 1;
        }

        public class CacheItem
        {
            public int Value;
            public int Key;
            public int Count;
        }
    }
}
