using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.DynamicProgrammingProblems
{
    public class JumpGameII
    {
        public int Jump(int[] nums)
        {
            if (nums.Length < 2) return 0;
            var left = 0; var i = 0; var max = 0;
            var level = 0; var next = 0;
            while (max - i + 1 > 0) // nodes count of current level>0
            {
                level++;
                for (; i <= max; i++)
                {
                    next = Math.Max(next, i + nums[i]); // traversal current level, update mac reach of next level
                    if (next >= nums.Length - 1) return level;// if last element is in level+1, retrn jump = level;
                }
                max = next;
            }

            return 0;
        }

        public int Jump_Greedy(int[] nums)
        {
            int jumps = 0, curEnd = 0, curFarthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                curFarthest = Math.Max(curFarthest, i + nums[i]);
                if (i == curEnd)
                {
                    jumps++;
                    curEnd = curFarthest;
                }
            }
            return jumps;
        }

        /// <summary>
        /// 80/92
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int JumpTLEWithVisitied(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            var level = 0;
            var max = 0;
            var i = 0;
            var q = new Queue<int>();
            q.Enqueue(i++);
            var visitied = new bool[nums.Length];
            visitied[0] = true;

            while (q.Count > 0)
            {
                var count = q.Count;
                var small = i;
                for (var j = 0; j < count; j++)
                {
                    var p = q.Dequeue();
                    var right = p + nums[p];
                    max = Math.Max(right, max);

                    if (max >= nums.Length - 1)
                    {
                        return level + 1;
                    }

                    for (var k = 1; k <= nums[p]; k++)
                    {
                        if (visitied[p + k]) continue;
                        q.Enqueue(p + k);
                        visitied[p + k] = true;
                    }
                }
                level++;
            }

            return level;
        }
        public int JumpWrong(int[] nums)
        {
            if (nums.Length == 1) return 0;
            var left = 0;
            var right = 0;
            var min = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (right < i + nums[i])
                {
                    min++;
                    left = right;
                    right = i + nums[i]; // left is most left with current jump

                }

                if (right >= nums.Length - 1)
                {
                    return min;
                }
            }

            return min;
        }

        /// <summary>
        /// 91/92 only fail last input
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int JumpTLE(int[] nums)
        {
            if (nums.Length == 1) return 0;
            var max = 0;
            var dp = new int[nums.Length];

            for (var i = 1; i < nums.Length; i++) dp[i] = nums.Length;
            dp[0] = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var mostright = i + nums[i];
                max = Math.Max(max, mostright);
                if (max >= nums.Length - 1) return i == 0 ? 0 : dp[i] + 1;

                for (var j = i + 1; j <= max; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[i] + 1);
                }
            }

            return dp[nums.Length - 1];
        }
    }
}
