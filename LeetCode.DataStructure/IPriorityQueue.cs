using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure
{
    interface IPriorityQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Seek();
        int Count { get; }
    }
}
