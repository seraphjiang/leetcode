using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class BasicCalculatorII
    {
        public const string nums = "0123456789";

        public int Calculate(string s)
        {
            var total = 0;
            var sign = 1;
            var i = 0;
            var num = GetNextNum(s, ref i);

            while (i < s.Length)
            {
                var c = s[i];
                ++i;
                if (c == '+' || c == '-')
                {
                    total += sign * num;
                    num = GetNextNum(s, ref i);
                    sign = c == '+' ? 1 : -1;
                }
                else if (c == '*')
                {
                    num *= GetNextNum(s, ref i);
                }
                else if (c == '/')
                {
                    num /= GetNextNum(s, ref i);
                }
            }
            total += sign * num;
            return total;
        }

        public int GetNextNum(string s, ref int start)
        {
            var num = 0;
            while (start < s.Length)
            {
                if (nums.Contains(s[start]))
                {
                    num = num * 10 + (s[start] - '0');
                }
                else if (s[start] != ' ')
                {
                    return num;
                }
                start++;
            }

            return num;
        }
    }
}
