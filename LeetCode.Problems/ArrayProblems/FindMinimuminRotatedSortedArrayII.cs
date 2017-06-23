using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    public class FindMinimuminRotatedSortedArrayII
    {
        public int FindMin(int[] nums)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] > nums[hi])
                {
                    lo = mid + 1;
                }
                else if (nums[mid] < nums[hi])
                {
                    hi = mid;
                }
                else
                {
                    hi--;// because we are ask for min/
                }
            }

            return nums[lo];
        }
    }
}
