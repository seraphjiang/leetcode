using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    public class MaximumGapProblem
    {
        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;
            var max = 0;
            RadixSort(nums);
            for (var i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i] - nums[i - 1]);
            }

            return max;
        }

        private void RadixSort(int[] nums)
        {
            var radix = 10;
            var exp = 1;
            
            var index = new int[nums.Length];
            var max = nums.Max();
            while (max / exp > 0)
            {
                var count = new int[radix];
                for (var i = 0; i < nums.Length; ++i)
                    count[(nums[i] / exp) % radix]++;
                for (var i = 1; i < count.Length; ++i)
                    count[i] += count[i - 1];
                for (var i = nums.Length - 1; i >= 0; i--)
                    index[--count[nums[i] / exp % radix]] = nums[i];
                for (var i = 0; i < nums.Length; i++)
                    nums[i] = index[i];

                exp *= radix;
            }
        }

        /// <summary>
        /// O(log(N)) solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumGap1(int[] nums)
        {
            if (nums.Length < 2) return 0;
            var max = 0;

            Array.Sort(nums);

            for (var i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i] - nums[i - 1]);
            }

            return max;
        }
    }
}
