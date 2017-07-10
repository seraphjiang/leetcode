using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    /// <summary>
    /// https://leetcode.com/problems/wiggle-sort/#/description
    /// Given an unsorted array nums, reorder it in-place such that nums[0] <= nums[1] >= nums[2] <= nums[3]....
    /// For example, given nums = [3, 5, 2, 1, 6, 4], one possible answer is [1, 6, 2, 5, 3, 4].
    /// </summary>
    [Problem(Company =  "Google" , Level = Level.Median)]
    public class WiggleSortProblem
    {
        public void WiggleSort(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (i != 0 && nums[i] > nums[i - 1]) Swap(nums, i, i - 1);
                }
                else
                {
                    if (nums[i - 1] > nums[i]) Swap(nums, i, i - 1);
                }
            }
        }

        public void Swap(int[] nums, int i, int j)
        {
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
