using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week34
{
    public class ArrayNestingIndexJump
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        public int ArrayNesting(int[] nums)
        {
            var n = nums.Length;
            var max = 0;
            var visitied = new bool[n];
             // key = k , value = max len while k as key from here.
            for (var i = 0; i < nums.Length; ++i)
            {
                if (visitied[i]) continue;
                if (dict.ContainsKey(i))
                {
                    max = max = Math.Max(max, dict[i]);
                }
                else
                {
                    var len = 0;
                    var k = i;
                    while (!visitied[k])
                    {
                        visitied[k] = true;
                        len++;
                        k = nums[k];
                    }
                    
                    dict[i] = len;
                    max = Math.Max(max, len);
                }
                
                if (max > (n / 2)) return max;
            }

            return max;
        }
    }
}
