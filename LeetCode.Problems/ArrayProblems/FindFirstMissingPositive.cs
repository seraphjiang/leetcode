using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    public class FindFirstMissingPositive
    {
        public int FirstMissingPositiveWithSpace(int[] nums)
        {
            var target = new int[nums.Length];
            foreach (var n in nums)
            {
                if (n < 1 || n > nums.Length) continue;
                target[n - 1] = n;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (target[i] != i + 1) return i + 1;
            }

            return nums.Length + 1;
        }

        public int FirstMissingPositive(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                while ((nums[i] > 0) && (nums[i] <= nums.Length) && (nums[i] != nums[nums[i] - 1]))
                {
                    /*below is wrong way to swap, because nums[i] is not invariable 
                    var temp = nums[i];
                    nums[i] = nums[nums[i] - 1];
                    nums[nums[i] - 1] = temp;
                    */
                    var temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;

                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1) return i + 1;
            }

            return nums.Length + 1;
        }
    }
}
