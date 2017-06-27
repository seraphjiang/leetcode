using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class BurstBalloons
    {
        public int MaxCoins(int[] nums)
        {
            var nums1 = new int[nums.Length + 2];
            var i = 1;
            foreach (var n in nums)
            {
                if (n != 0) nums1[i++] = n;
            }

            nums1[0] = nums1[i++] = 1;
            var memo = new int[i, i];
            return Burst(nums1, memo, 0, i - 1);
        }

        int Burst(int[] nums, int[,] memo, int left, int right)
        {
            if (left + 1 == right) return 0;// very import, 
            if (memo[left, right] > 0) return memo[left, right];
            var res = 0;
            for (var i = left + 1; i < right; i++)
            {
                res = Math.Max(res, nums[left] * nums[i] * nums[right] + Burst(nums, memo, left, i) + Burst(nums, memo, i, right));
            }

            memo[left, right] = res;
            return memo[left, right];
        }
    }
}
