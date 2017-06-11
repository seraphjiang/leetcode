using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week36
{
    /// <summary>
    /// 611. Valid Triangle Number My SubmissionsBack To Contest
    /// </summary>
    public class ValidTriangleNumber
    {
        public int TriangleNumber(int[] nums)
        {
            var res = 0;
            Array.Sort(nums);
            for (var i = 0; i < nums.Length - 2; ++i)
            {
                for (var j = i + 1; j < nums.Length - 1; ++j)
                {
                    var right = nums.Length;
                    var left = j;
                    var sum = nums[i] + nums[j];
                    while (right - left > 1) // because we use right =n and start from j, right must large that left more than 1.
                    {
                        var mid = (left + right) / 2;
                        if (nums[mid] >= sum) // not qualify
                        {
                            right = mid;
                        }
                        else
                        {
                            left = mid;
                        }
                    }

                    res += left - j;
                }
            }
            return res;
        }
    }
}
