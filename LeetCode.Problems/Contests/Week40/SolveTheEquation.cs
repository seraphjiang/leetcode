using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week40
{
    public class SolveTheEquation
    {
        public string SolveEquation(string equation)
        {
            var eqs = equation.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var left = eqs[0];
            var right = eqs[1];


            var l = 0;
            var r = 0;
            
            var sign = left[0] == '-' ? -1 : 1;
            var i = left[0] == '-' ? 1 : 0;
            var start = i;
            while (i < left.Length)
            {
                if (left[i] == '+' || left[i] == '-' || i == left.Length - 1)
                {
                    if (i == left.Length - 1) i++;
                    if (left[i - 1] == 'x')
                    {
                        var sub = left.Substring(start, (i - 1 - start));
                        l += sign * (sub.Length == 0 ? 1 : int.Parse(sub));
                    }
                    else
                    {
                        r += -sign * int.Parse(left.Substring(start, (i - start)));
                    }

                    if (i == left.Length) break;
                    sign = left[i] == '+' ? 1 : -1;
                    start = i + 1;
                }
                i++;
            }
            i = right[0] == '-' ? 1 : 0;
            start = i;
            sign = right[0] == '-' ? -1 : 1;
            while (i < right.Length)
            {
                if (right[i] == '+' || right[i] == '-' || i == right.Length - 1)
                {
                    if (i == right.Length - 1) i++;

                    if (right[i - 1] == 'x')
                    {
                        var sub = right.Substring(start, (i - 1 - start));
                        l += -sign * (sub.Length == 0 ? 1 : int.Parse(sub));
                    }
                    else
                    {
                        r += sign * int.Parse(right.Substring(start, (i - start)));
                    }
                    if (i == right.Length) break;
                    sign = right[i] == '+' ? 1 : -1;
                    start = i + 1;
                }
                i++;
            }

            if (l == 0 && r == 0) return "Infinite solutions";
            if (l == 0 && r != 0) return "No solution";

            return string.Format("x={0}", r / l);
        }
    }
}
