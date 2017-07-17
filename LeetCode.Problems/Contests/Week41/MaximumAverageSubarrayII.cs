using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week41
{
    public class MaximumAverageSubarrayII
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            double left = int.MinValue; double right = int.MaxValue;

            while ((right - left) > 0.00001)
            {
                double mid = (right + left) / 2;
                if (HasAboveAverage(nums, k, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return right;
        }

        private bool HasAboveAverage(int[] nums, int k, double target)
        {
            double sum = 0; double preSum = 0;
            for (var i = 0; i < k; i++) sum += nums[i] - target;
            if (sum >= 0) return true;

            var cur = k;
            while (cur < nums.Length)
            {
                sum += nums[cur] - target;
                preSum += nums[cur - k] - target;
                if (preSum < 0)
                {
                    sum -= preSum;
                    preSum = 0;
                }
                if (sum >= 0) return true;
                cur++;
            }

            return sum >= 0;
        }

        public double FindMaxAverageTLE(int[] nums, int k)
        {
            var sums = new double[nums.Length];
            sums[0] = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                sums[i] = sums[i - 1] + nums[i];
            }

            double max = double.MinValue;

            for (var i = k; i <= nums.Length; i++)
            {
                for (var j = 0; j + i - 1 < nums.Length; j++)
                {
                    //Console.WriteLine(j+i-1);
                    var sub = GetSum(sums, j, j + i - 1);
                    max = Math.Max(max, sub / i);
                }
            }

            return max;
        }

        public double GetSum(double[] sums, int i, int j)
        {
            if (i == 0) return sums[j];
            return sums[j] - sums[i - 1];
        }
    }
}
