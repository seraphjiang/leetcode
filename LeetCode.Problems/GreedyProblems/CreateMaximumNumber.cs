using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.GreedyProblems
{
    public class CreateMaximumNumber
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int len1 = nums1.Length, len2 = nums2.Length;
            var ret = new int[k];
            if (len1 + len2 < k)
            {
                return ret;
            }
            else if (len1 + len2 == k)
            {
                return Merge(nums1, nums2, k);
            }
            else
            {
                for (var i = 0; i <= k; i++)
                {
                    if (i <= len1 && (k - i) <= len2) // don't forget to add this check. 
                    {
                        var n1 = GetKMaxFromArray(nums1, i);
                        var n2 = GetKMaxFromArray(nums2, k - i);
                        var curr = Merge(n1, n2, k);
                        if (Compare(curr, 0, ret, 0)) ret = curr;
                    }
                }
            }
            return ret;
        }

        private int[] GetKMaxFromArray(int[] nums, int k)
        {
            var ret = new int[k];
            if (k == 0) return ret;
            int len = nums.Length;
            var idx = 0;
            for (var i = 0; i < len; i++)
            {
                // 123456 k=4, 6 get 4;[3456]
                // as long as left nums >=k, we could replace pre, if current is large than pre
                // rest nums =  already get nums + left nums = idx + (len-i-1)
                // compare ret[idx - 1] < nums[i], not nums[idx - 1] < nums[i] 
                while (idx > 0 && ret[idx - 1] < nums[i] && ((len - i -1 + idx) >= k)) idx--;
                if (idx < k) ret[idx++] = nums[i];
            }
            return ret;
        }

        public int[] Merge(int[] nums1, int[] nums2, int k)
        {
            var ret = new int[k];
            int l = 0, r = 0;
            for (var i = 0; i < k; i++)
            {
                if (Compare(nums1, l, nums2, r))
                {
                    ret[i] = nums1[l++];
                }
                else
                {
                    ret[i] = nums2[r++];
                }
            }
            return ret;
        }
        public bool Compare(int[] nums1, int i, int[] nums2, int j)
        {
            while (i < nums1.Length && j < nums2.Length && nums1[i] == nums2[j]) { i++;j++; }
            return j == nums2.Length || (i < nums1.Length && nums1[i] > nums2[j]);
        }


        /// <summary>
        /// 25/102
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxNumberWrong(int[] nums1, int[] nums2, int k)
        {

            var n = nums1.Length + nums2.Length;
            if (k > n || (nums1.Length == 0 && nums2.Length == 0))
            {
                return new int[] { };
            }
            else if (k == n)
            {
                var n3 = nums1.Concat(nums2).ToArray();
                var n4 = nums2.Concat(nums1).ToArray();
                for (var o = 0; o < n; o++)
                {
                    if (n3[o] == n4[o]) continue;
                    return n3[o] > n4[o] ? n3 : n4;
                }
            }

            var count = n - k + 1;
            var ret = new List<int>();
            var i = GetMaxIndex(nums1, 0, count);
            var j = GetMaxIndex(nums2, 0, count);
            var n1 = nums1.Skip(i + 1).ToArray();
            var n2 = nums2.Skip(j + 1).ToArray();
            if (nums1.Length == 0)
            {
                ret.Add(nums2[j]);
                ret.AddRange(MaxNumber(nums1, n2, k - 1));
                return ret.ToArray();
            }
            else if (nums2.Length == 0)
            {
                return MaxNumber(nums2, nums1, k);
            }

            // pick first n-k+1, so we still have k-1 number left for select
            if (nums1[i] == nums2[j])
            {
                if (Compare(n1, n2) >= 0)
                {
                    ret.Add(nums1[i]);
                    ret.AddRange(MaxNumber(n1, nums2, k - 1));
                }
                else
                {
                    ret.Add(nums2[j]);
                    ret.AddRange(MaxNumber(nums1, n2, k - 1));
                }
            }
            else
            {
                if (nums1[i] > nums2[j])
                {
                    ret.Add(nums1[i]);
                    ret.AddRange(MaxNumber(n1, nums2, k - 1));
                }
                else
                {
                    ret.Add(nums2[j]);
                    ret.AddRange(MaxNumber(nums1, n2, k - 1));
                }
            }

            return ret.ToArray();
        }

        int GetMaxIndex(int[] nums, int start, int count)
        {
            var max = start;
            for (var i = start; i < nums.Length && (i - start) < count; i++)
            {
                if (nums[i] > nums[max]) max = i;
            }

            return max;
        }

        int Compare(int[] nums1, int[] nums2)
        {
            return string.Join("", nums1).CompareTo(string.Join("", nums2));
        }
    }
}
