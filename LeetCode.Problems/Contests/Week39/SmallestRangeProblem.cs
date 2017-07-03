using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week39
{
    public class SmallestRangeProblem
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var start = -1;
            var end = -1;
            var max = int.MinValue;
            var pq = new PriorityQueue<int[]>((a, b) => a[0] - b[0]);
            var range = int.MaxValue;
            for (var i = 0; i < nums.Count; i++)
            {
                pq.Enqueue(new[] { nums[i][0], i, 0 }); // val, row, col
                if (nums[i][0] > max) max = nums[i][0];
            }

            while (pq.Count == nums.Count)
            {
                var cur = pq.Dequeue();
                if (range > max - cur[0])
                {
                    range = max - cur[0];
                    start = cur[0];
                    end = max;
                }
                // cur[2] is col, cur[1] is row
                if (cur[2] + 1 < nums[cur[1]].Count)
                {
                    cur[2]++;
                    cur[0] = nums[cur[1]][cur[2]];
                    pq.Enqueue(cur);
                    if (cur[0] > max) max = cur[0];
                }
            }

            return new[] { start, end };
        }

        public class PriorityQueue<T>
        {
            private Comparison<T> comparison;
            private List<T> list = new List<T>();
            public PriorityQueue(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Count
            {
                get
                {
                    return list.Count;
                }
            }
            public T Peek()
            {
                return list[0];
            }

            /// <summary>
            /// A little bit hard to implement sift up/down, 
            /// so just maintain a sorted list via using binary search
            /// O(log(N)) for enqueue 
            /// </summary>
            /// <param name="val"></param>
            public void Enqueue(T val)
            {
                var i = list.BinarySearch(val, Comparer<T>.Create(this.comparison));
                i = i >= 0 ? i : ~i;
                list.Insert(i, val);
            }

            public T Dequeue()
            {
                var val = list[0];
                list.RemoveAt(0);
                return val;
            }
        }
    }
}