using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week36
{
    public class AddBoldTaginString
    {
        public string AddBoldTag(string s, string[] dicts)
        {
            var dp = new bool[s.Length];
            var dict = new HashSet<string>(dicts);
            for (var i = 0; i < s.Length; ++i)
            {
                var len = 0;
                foreach (var d in dicts)
                {
                    if (i + d.Length <= s.Length && s.Substring(i, d.Length).Equals(d))
                    {
                        len = Math.Max(len, d.Length);
                    }
                }

                for (var j = i; j < i + len; j++)
                {
                    dp[j] = true;
                }
            }

            var sb = new StringBuilder();

            for (var i = 0; i < s.Length; i++)
            {
                if (!dp[i])
                {
                    sb.Append(s[i]); continue;
                }

                var j = i;
                sb.Append("<b>");
                while (j < s.Length && dp[j])
                {
                    sb.Append(s[j]);
                    j++;
                }

                sb.Append("</b>");

                i = j - 1;
            }
            return sb.ToString();
        }
    }
}
