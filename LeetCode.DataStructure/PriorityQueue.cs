using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure
{
    public abstract class PriorityQueue<T>:IPriorityQueue<T>
    {


        public abstract int Count { get; }

        public abstract T Dequeue();
        public abstract void Enqueue(T item);
        public abstract T Seek();
    }
}
