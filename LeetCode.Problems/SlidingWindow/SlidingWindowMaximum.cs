using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.SlidingWindow
{
    /// <summary>
    /// 239. Sliding Window Maximum
    /// https://leetcode.com/problems/sliding-window-maximum/#/description
    /// </summary>
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0) return new int[0];

            var res = new int[nums.Length - k + 1];
            var deque = new LinkedList<int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                // remove from head, for those don't belong to k window size element
                // the size of window don't has to be exactly k. as long as the first index is valid 
                while (deque.Any() && deque.First() < i - k + 1) // to maintain a k window, i - x +1 = k, x = i-k+1, for all less than x, we need to remove it.
                {
                    deque.RemoveFirst();
                }

                // for those element small than nums[i] but distance to it is less than k.(which means still in queue)
                // just remove it, because for any case, nums[i] is always better candidate.
                while(deque.Any() && nums[deque.Last()] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1) // when i = k-1, window size = i - 0 +1 = k-1+1 = k. now we could push valid answer to result
                {
                    res[i - k + 1] = nums[deque.First()]; 
                }
            }

            return res;
        }
    }
}