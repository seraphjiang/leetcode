using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Amazon
{
    public class CalculateScore
    {
        static void Main(string[] args)
        {
            var ret = totalScore(new string[] { "5", "-2", "4", "Z", "X", "9", "+", "+" }, 8);
        }
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int totalScore(string[] blocks, int n)
        {
            if (n == 0) return 0;
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 0; i < n; i++)
            {
                if (blocks[i] == "X")
                {
                    var p = stack.Count > 0 ? stack.Peek() : 0;
                    stack.Push(p * 2);
                }
                else if (blocks[i] == "+")
                {
                    var p2 = stack.Count > 0 ? stack.Pop() : 0;
                    var p1 = stack.Count > 0 ? stack.Pop() : 0;
                    stack.Push(p1);
                    stack.Push(p2);
                    stack.Push(p1 + p2);
                }
                else if (blocks[i] == "Z")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(int.Parse(blocks[i]));
                }
            }

            var total = 0;
            while (stack.Count > 0)
            {
                total += stack.Pop();
            }

            return total;
        }        // METHOD SIGNATURE ENDS
    }
}
