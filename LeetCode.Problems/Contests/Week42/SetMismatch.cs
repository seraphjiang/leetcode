using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week42
{
    public class SetMismatch
    {
        public int[] FindErrorNums(int[] nums)
        {
            int[] find = new int[nums.Length];
            var first = 0;
            var second = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                find[nums[i] - 1]++;
                if (find[nums[i] - 1] == 2) first = nums[i];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (find[i] == 0)
                {
                    second = i + 1;
                    break;
                }
            }

            return new int[] { first, second };
        }
    }
}
