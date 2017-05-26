using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.Standalone
{
    /// <summary>
    /// This is copy from internet, however, i don't think the siftup/siftdown implementation is correct.
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
        /// </summary>
        /// <param name="v"></param>
        public void Push(T v)
        {
            if (Count >= heap.Length)
            {
                Array.Resize(ref heap, Count * 2);
            }

            heap[Count] = v;
            SiftUp(Count++);
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
                SiftDown(0);
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

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n / 2; n > 0; n = n2, n2 /= 2)
            {
                if (comparer.Compare(v, heap[n2]) > 0)
                {
                    heap[n] = heap[n2];
                }
                else
                {
                    break;
                }
            }
            heap[n] = v;
        }

        void SiftUp2()
        {
            // n always equals to size-1 at the begining.
            var n = Count - 1;
            var v = heap[n]; // save the last item of heap tree. we suppose to find a place for this item in tree.

            for (var n2 = n / 2; n > 0; n = n2, n2 /= 2)
            {
                // for a zero based heap array.
                // left child index is parent*2 +1;
                // right child index is parent*2 +2;
                // so parent index is (left-1)/2 or (right-2)/2 or (right-1)/2 conside round result to int.
                // what is index /2.
                // if node is left , e.g. 1,3,5,7   the index/2 is parent 0,1,2,3.
                // if node is right, e.g. 2,4,6,8 the index/2 is next node of parent when do level traveral. 
                if (comparer.Compare(v, heap[n2]) > 0)
                {
                    heap[n] = heap[n2];
                }
                else
                {
                    break;
                }
            }
            heap[n] = v;
        }


        void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0)
                {
                    n2++;
                }
                if (comparer.Compare(v, heap[n2]) >= 0) // if find a node which small than v[the last we use to replace remove top one.] we could stop.
                {
                    break;
                }
                heap[n] = heap[n2]; //assign child node to the current parent(top) since it is large than v. 
            }
            heap[n] = v;
        }

        void SiftDown2(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0)
                {
                    n2++;
                }
                if (comparer.Compare(v, heap[n2]) >= 0) // if find a node which small than v[the last we use to replace remove top one.] we could stop.
                {
                    break;
                }
                heap[n] = heap[n2]; //assign child node to the current parent(top) since it is large than v. 
            }
            heap[n] = v;
        }
    }
}
