using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week42
{
    public class MaximumLengthofPairChain
    {
        public int FindLongestChain(int[,] pairs)
        {
            var n = pairs.GetLength(0);
            if (n == 0) return 0;
            var ps = new Pair[n];
            for (var i = 0; i < n; i++)
            {
                ps[i] = new Pair(pairs[i, 0], pairs[i, 1]);
            }

            Array.Sort(ps, (x, y) => (x.start == y.start) ? (x.end - y.end) : (x.start - y.start));

            var dp = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }

            for (var i = n - 1; i >= 0; i--)
            {
                var max = 1;
                for (var j = i; j < n; j++)
                {
                    if (i == j)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    { // j > i
                        if (ps[j].start > ps[i].end)
                        {
                            max = Math.Max(max, dp[j, n - 1] + 1);
                        }
                        else
                        {
                            max = Math.Max(max, dp[j, n - 1]);
                        }
                    }
                    dp[i, j] = max;
                }
            }

            return dp[0, n - 1];
        }
        public int FindLongestChainTLE(int[,] pairs)
        {
            var n = pairs.GetLength(0);
            if (n == 0) return 0;
            var ps = new Pair[n];
            for (var i = 0; i < n; i++)
            {
                ps[i] = new Pair(pairs[i, 0], pairs[i, 1]);
            }

            Array.Sort(ps, (x, y) => (x.start == y.start) ? (x.end - y.end) : (x.start - y.start));

            var queue = new Queue<int>();
            var level = 0;
            var start = ps[0];
            queue.Enqueue(0);
            for (var i = 1; i < n; i++)
            {
                if (ps[i].start <= start.end)
                {
                    queue.Enqueue(i);
                }
                else
                    break;
            }

            //Console.WriteLine(queue.Count);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                level++;
                //Console.WriteLine("count:{0}", count);
                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    //Console.Write(node);
                    //Console.Write(",");
                    for (var j = node + 1; j < n; j++)
                    {
                        if (ps[j].start <= ps[node].end) continue;
                        //Console.Write("add to queue:{0}", j);
                        queue.Enqueue(j);
                    }
                }
                //Console.WriteLine();
            }

            return level;
        }

        public class Pair
        {
            public int start;
            public int end;
            public Pair(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }
    }
}
