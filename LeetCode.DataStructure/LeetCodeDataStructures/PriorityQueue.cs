using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.LeetCodeDataStructures
{
    /// <summary>
    /// Mini Heap as default comparasion direction (a,b)=>a-b;
    /// Max Heap when reverse default direction (a,b)=> b-a;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        internal IComparer<T> comparer;

        internal T[] heap;
        public int Count { get; private set; }

        public PriorityQueue(int capacity = 16, IComparer<T> comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            this.heap = new T[capacity];
        }

        /// <summary>
        /// To add an element to a heap we must perform an up-heap operation (also known as bubble-up, percolate-up, sift-up, trickle-up, heapify-up, or cascade-up), by following this algorithm:
        //  1.Add the element to the bottom level of the heap.
        /// 2.Compare the added element with its parent; if they are in the correct order, stop.
        /// 3.If not, swap the element with its parent and return to the previous step.
        /// be careful:
        /// The downward-moving node is swapped with the larger of its children in a max-heap (in a min-heap it would be swapped with its smaller child), until it satisfies the heap property in its new position. This functionality is achieved by the Max-Heapify function as defined below in pseudocode for an array-backed heap A of length heap_length[A]. Note that "A" is indexed starting at 1.
        /// </summary>
        /// <param name="v"></param>
        public void Push(T v)
        {
            if (Count >= heap.Length)
            {
                Array.Resize(ref heap, Count * 2);
            }

            heap[Count] = v;
            Count++;
            SiftUp();
        }

        /// <summary>
        /// The procedure for deleting the root from the heap (effectively extracting the maximum element in a max-heap or the minimum element in a min-heap) and restoring the properties is called down-heap (also known as bubble-down, percolate-down, sift-down, trickle down, heapify-down, cascade-down, and extract-min/max).
        /// 1. Replace the root of the heap with the last element on the last level.
        /// 2. Compare the new root with its children; if they are in the correct order, stop.
        /// 3. If not, swap the element with one of its children and return to the previous step. (Swap with its smaller child in a min-heap and its larger child in a max-heap.)
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var v = Top();
            heap[0] = heap[--Count];
            if (Count > 1)
            {
                SiftDown();
            }

            return v;
        }

        public T Top()
        {
            if (Count > 0)
            {
                return heap[0];
            }

            throw new InvalidOperationException("");
        }

        void SiftUp()
        {
            var n = Count - 1;
            var v = heap[n];

            while (n > 0)
            {
                var parent = (n - 1) / 2;
                // for min heap
                if (comparer.Compare(v, heap[parent]) < 0)
                {
                    heap[n] = heap[parent];
                    n = parent;
                }
                else
                {
                    break;
                }
            }

            heap[n] = v;
        }

        void SiftDown()
        {
            var n = 0;
            var v = heap[n];

            while (n < Count)
            {
                var left = n * 2 + 1;
                var right = n * 2 + 2;
                var smallest = n;
                if(left<Count&& comparer.Compare(v, heap[left]) > 0)
                {
                    smallest = left;
                }

                if(right<Count&&comparer.Compare(v, heap[right]) > 0&& ((left<Count && comparer.Compare(heap[left], heap[right]) > 0) || (left>=Count)))
                {
                    smallest = right;
                }

                if (smallest == n)
                {
                    break;//cannot find child smaller than heap[n]; stop siftdown
                }

                heap[n] = heap[smallest]; //otherwise let heap[parent] = heap[smallest], and move parent index to smallest
                n = smallest;
            }

            heap[n] = v;
        }
    }
}
