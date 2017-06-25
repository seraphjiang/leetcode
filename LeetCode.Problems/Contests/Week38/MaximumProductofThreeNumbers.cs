using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week38
{
    public class MaximumProductofThreeNumbers
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);

            var ret = nums[nums.Length - 1];

            ret *= Math.Max(nums[0] * nums[1], nums[nums.Length - 2] * nums[nums.Length - 3]);

            return ret;
        }
    }
}
