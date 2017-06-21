using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3)) return true;
            if (string.IsNullOrEmpty(s3)) return false;
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return s3.Equals(s1 + s2);

            if (s1.Length + s2.Length != s3.Length) return false;
            if (s3.Equals(s1 + s2)) return true;
            if (s3.Equals(s2 + s1)) return true; return IsInterleave(s1, 0, s2, 0, s3, 0);
        }

        Dictionary<string, bool> Cache = new Dictionary<string, bool>();
        public bool IsInterleave(string s1, int i, string s2, int j, string s3, int k)
        {
            var key = string.Format("{0},{1},{2}", i, j, k);
            if (Cache.ContainsKey(key)) return Cache[key];

            if (k == s3.Length) return true;
            if (i < s1.Length && s1[i] == s3[k])
            {
                if (IsInterleave(s1, i + 1, s2, j, s3, k + 1))
                {
                    Cache[key] = true;
                    return true;
                }
            }

            if (j < s2.Length && s2[j] == s3[k])
            {
                if (IsInterleave(s1, i, s2, j + 1, s3, k + 1))
                {
                    Cache[key] = true;
                    return true;
                }
            }

            Cache[key] = false;
            return false;
        }


        /// <summary>
        /// 94/101
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleaveBacktracking(string s1, string s2, string s3)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3)) return true;
            if (string.IsNullOrEmpty(s3)) return false;
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return s3.Equals(s1 + s2);

            if (s1.Length + s2.Length != s3.Length) return false;
            if (s3.Equals(s1 + s2)) return true;
            if (s3.Equals(s2 + s1)) return true;

            var dict = new Dictionary<char, int>();
            var s = s1 + s2;
            for (var i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i])) dict[s[i]] = 0;
                if (!dict.ContainsKey(s3[i])) dict[s3[i]] = 0;
                dict[s[i]]++;
                dict[s3[i]]--;
            }

            foreach (var kv in dict)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }

            if (s1[0] == s3[0])
            {
                if (IsInterleave(s1.Substring(1), s2, s3.Substring(1))) return true;
            }

            if (s2[0] == s3[0])
            {
                if (IsInterleave(s1, s2.Substring(1), s3.Substring(1))) return true;
            }
            return false;
        }

    }
}
