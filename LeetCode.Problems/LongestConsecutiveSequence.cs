using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            var max = 0;
            var dict = new Dictionary<int, int>();
            foreach(var n in nums)
            {
                if (!dict.ContainsKey(n))
                {
                    var left = dict.ContainsKey(n - 1) ? dict[n - 1] : 0;
                    var right = dict.ContainsKey(n + 1) ? dict[n + 1] : 0;
                    var sum = left + right + 1;
                    dict[n] = sum;
                    max = Math.Max(max, sum);
                    //expend boundary;
                    // we could do this w/o worry about missing interval,
                    // because the result should be consective
                    dict[n - left] = sum;
                    dict[n + right] = sum;
                }
            }
            return max;
        }
        /// <summary>
        /// o(n log(n))
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive1(int[] nums)
        {
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            var max = 1;
            var sofar = 1;
            var pre = nums[0];
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    sofar++;
                }
                else if (nums[i] == nums[i - 1])
                {

                }
                else
                {
                    sofar = 1;
                }
                max = Math.Max(max, sofar);
            }

            return max;
        }
    }
}