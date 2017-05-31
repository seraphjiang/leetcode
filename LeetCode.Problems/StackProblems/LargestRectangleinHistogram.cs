using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StackProblems
{
    public class LargestRectangleinHistogram
    {
        /// <summary>
        /// naive O(n^2)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleAreaTLE(int[] heights)
        {
            var n = heights.Length;
            var max = 0;
            for (var i = 0; i < n; ++i)
            {
                var min = heights[i];
                for (var j = i; j < n; ++j)
                {
                    min = Math.Min(min, heights[j]);
                    max = Math.Max(min * (j - i + 1), max);
                }
            }

            return max;
        }
        public int LargestRectangleArea(int[] heights)
        {
            var max = 0;
            var stack = new Stack<int>(); // keep increase stack so we could back track to stack.top() for left most

            for (var i = 0; i < heights.Length; i++)
            {
                if (stack.Count == 0 || heights[i] >= heights[stack.Peek()])
                {
                    stack.Push(i);//becasue height is keep increase, we could not determine right most
                }
                else
                {
                    // find a decrease, which means find right most.
                    var right = i;
                    var top = stack.Pop();// 1 minus left beside right.


                    var height = heights[top];// this is height bar between left and right
                    while (stack.Count > 0 && heights[stack.Peek()] == height)
                    {
                        stack.Pop();// for all bar height equals , we could calc once.
                    }

                    var left = stack.Count == 0 ? -1 : stack.Peek(); // this is left boundard, because, that's the fisrt left one smaller than top
                    // if there is no more left itemi in stack, then left is -1, 
                    var width = right - left - 1;

                   max =  Math.Max(max, height * width);

                    i--;// this is important, we still need to calc bar for index = i;
                }
            }

            //for rest of keep increase stack haven't pop;
            if (stack.Count > 0)
            {
                var right = stack.Peek() + 1;
                while (stack.Count > 0)
                {
                   //Assert right = heights.Length;
                    var top = stack.Pop();
                    var left = stack.Count == 0 ? -1 : stack.Peek();
                    var height = heights[top];
                    var width = right - left - 1;
                    max = Math.Max(max, height * width);
                }
            }

            return max;
        }
    }
}
