using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    public class MedianofTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;

            var midl = (m + n + 1) / 2;
            var midr = (m + n + 2) / 2;// midr!=midl+1 for odd case
            return (GetKth(nums1, 0, nums2, 0, midl) + GetKth(nums1, 0, nums2, 0, midr)) / 2.0; // divided 2.0 to auto cast to double
        }

        public double GetKth(int[] n1, int ls, int[] n2, int rs, int k)
        {
            // for the case, n1 or n2 is used up, we only need to care about another.
            if (ls >= n1.Length) return n2[rs + (k - 1)]; // k is 1 based, so subtract 1 to convert to index
            if (rs >= n2.Length) return n1[ls + (k - 1)];

            //
            if (k == 1)
            {
                return Math.Min(n1[ls], n2[rs]);
            }

            ////calc median
            //var midl = ls + k / 2;
            //var midr = rs + k / 2;
            //// nums1, nums2 are different size, so even if ls, rs are valid, midl or midr could still be out of index range.
            //// therefore, we set the val to max, so, we will only search in left part.

            //var ml = midl < n1.Length ? n1[midl] : int.MaxValue;
            //var mr = midr < n2.Length ? n2[midr] : int.MaxValue;

            //if (ml < mr)
            //    return GetKth(n1, ls + k / 2 + 1, n2, rs, k / 2); // k - k/2 >= k/2
            //else
            //    return GetKth(n1, ls, n2, rs + k / 2 + 1, k / 2);// ignore k/2, keep search k-k/2;

            //calc median
            var midl = ls + k / 2 - 1; // the goal is to find kth, to do that, we need to compare k/2 of n1, n2
            var midr = rs + k / 2 - 1; // k is 1 based, find mid offset by plus k/2-1. e.g.  1,2,3 k = 3, mid offset is 
            // nums1, nums2 are different size, so even if ls, rs are valid, midl or midr could still be out of index range.
            // therefore, we set the val to max, so, we will only search in left part.

            var ml = midl < n1.Length ? n1[midl] : int.MaxValue;
            var mr = midr < n2.Length ? n2[midr] : int.MaxValue;

            if (ml < mr)
                return GetKth(n1, ls + k / 2, n2, rs, k - k / 2); // k - k/2 >= k/2
            else
                return GetKth(n1, ls, n2, rs + k / 2, k - k / 2);// ignore k/2, keep search k-k/2;

        }

        public double FindMedianSortedArraysWrong(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null) return 0;
            return Find(nums1, nums2, 0, nums1.Length - 1, 0, nums2.Length - 1);
        }

        public double Find(int[] nums1, int[] nums2, int ls, int le, int rs, int re)
        {
            if (nums1.Length == 0 && nums2.Length == 0) return 0;
            if (ls == le && rs == re) return (double)(nums1[ls] + nums2[rs]) / 2;
            if (ls > le || nums1.Length == 0)
            {
                return Median(nums2, rs, re);
            }
            if (rs > re || nums2.Length == 0)
            {
                return Median(nums1, ls, le);
            }

            if (nums1[nums1.Length - 1] <= nums2[0])
            {
                return Median(nums1, nums2);
            }

            if (nums2[nums2.Length - 1] <= nums1[0])
            {
                return Median(nums2, nums1);
            }

            var mid1 = Median(nums1, ls, le);
            var mid2 = Median(nums2, rs, re);

            if (mid1 == mid2) return mid1;
            else if (mid1 < mid2)
                return Find(nums1, nums2, (ls + le) / 2 + 1, le, rs, (rs + re) / 2);
            else
                return Find(nums2, nums1, (rs + re) / 2 + 1, re, ls, (ls + le) / 2);
        }

        private double Median(int[] nums1, int[] nums2)
        {
            if (nums1.Length == nums2.Length)
            {
                return (double)(nums1[nums1.Length - 1] + nums2[0]) / 2;
            }
            var mid = (nums1.Length + nums2.Length) / 2;
            if (nums1.Length < nums2.Length)
            {
                return ((nums1.Length + nums2.Length) % 2 == 0) ? (nums2[(mid - nums1.Length - 1)] + nums2[mid - nums1.Length]) / 2.0 : nums2[mid - nums1.Length];
            }
            else
            {
                return ((nums2.Length + nums1.Length) % 2 == 0) ? (nums1[mid - 1] + nums1[mid]) / 2 : nums1[mid];
            }
        }

        public double Median(int[] a, int s, int e)
        {
            if (s == e) return a[s];

            var mid = s + e;
            if ((mid) % 2 == 1) // zero based so (0+1)%2 == 1 is even
            {
                return ((double)a[(mid) / 2] + (double)a[(mid) / 2 + 1]) / 2;
            }
            else
            {
                return (double)a[mid / 2];
            }
        }
    }
}
