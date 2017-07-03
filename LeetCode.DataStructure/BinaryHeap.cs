using System;
using System.Collections.Generic;

namespace LeetCode.DataStructure
{
    public class BinaryHeap<T> : PriorityQueue<T>
    {
        internal List<T> list = new List<T>();
        internal Comparison<T> comparison;
        public BinaryHeap(Comparison<T> comparison = null)
        {
            this.comparison = comparison?? default(Comparison<T>);
        }

        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override T Dequeue()
        {
            var item = list[0];
            list.RemoveAt(0);
            return item;
        }

        public override void Enqueue(T item)
        {
            if (list.Count == 0)
            {
                list.Add(item);
            }
            else
            {
                var i = list.BinarySearch(item, Comparer<T>.Create(comparison));
                i = i >= 0 ? i : ~i;
                list.Insert(i, item);
            }
        }

        public override T Seek()
        {
            return list[0];
        }
    }
}
