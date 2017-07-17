using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week41
{
    public class MaximumAverageSubarrayI
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            if (nums.Length < k) return 0;
            var sums = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                sums[i] = (i == 0 ? 0 : sums[i - 1]) + nums[i];
                //Console.WriteLine(sums[i]);
            }
            double max = sums[k - 1];
            Console.WriteLine(max);
            for (var j = k; j < nums.Length; j++)
            {
                max = Math.Max(max, sums[j] - sums[j - k]);
                //Console.WriteLine(max);
            }

            return max / k;
        }
        public double FindMaxAverage1(int[] nums, int k)
        {
            if (nums.Length < k) return 0;
            double sum = 0;
            var len = 0;
            double max = double.MinValue;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                len++;

                if (len == k)
                {
                    max = Math.Max(max, sum);
                    len--;
                    sum -= nums[i - len];
                }
            }

            return max / k;
        }
    }
}
