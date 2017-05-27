using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.SlidingWindow
{
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0) return new int[0];

            var res = new int[nums.Length - k + 1];
            var deque = new LinkedList<int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                while (deque.Any() && deque.First() < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                while(deque.Any() && nums[deque.Last()] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                {
                    res[i - k + 1] = nums[deque.First()]; 
                }
            }

            return res;
        }
    }
}