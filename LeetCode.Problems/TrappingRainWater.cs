using LeetCode.DataStructure.Standalone.V2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class TrappingRainWater
    {
        /// <summary>
        /// 42. Trapping Rain Water
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
        ///
        /// For example,
        /// Given[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], return 6.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            var left = new int[height.Length];
            var right = new int[height.Length];
            var total = 0;
            for (var i = 0; i < height.Length; ++i)
            {
                left[i] = Math.Max(i == 0 ? height[i] : left[i - 1], height[i]);
                right[height.Length - 1 - i] = Math.Max(i == 0 ? height[height.Length - 1] : right[height.Length - i], height[height.Length - i - 1]);
            }

            for (var i = 0; i < height.Length; ++i)
            {
                total += Math.Min(left[i], right[i]) - height[i];
            }

            return total;
        }

        public int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        /// <summary>
        /// 407. Trapping Rain Water II
        /// Given an m x n matrix of positive integers representing the height of each unit cell in a 2D elevation map, compute the volume of water it is able to trap after raining.
        /// Note:
        /// Both m and n are less than 110. The height of each unit cell is greater than 0 and is less than 20,000.
        /// </summary>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        public int TrapRainWater(int[,] heightMap)
        {
            var total = 0;
            var m = heightMap.GetLength(0);
            var n = heightMap.GetLength(1);
            var visitied = new bool[m, n];
            var q = new PriorityQueue<int[]>(16, Comparer<int[]>.Create((a, b) => a[2] - b[2]));
            for (var i = 0; i < m; ++i)
            {
                q.Push(new int[] { i, 0, heightMap[i, 0] });
                Debug.Print(heightMap[i, 0].ToString());
                q.Push(new int[] { i, n - 1, heightMap[i, n - 1] });
                Debug.Print(heightMap[i, n - 1].ToString());
                visitied[i, 0] = visitied[i, n - 1] = true;// don't forget to set visited when init the queue
            }

            for (var i = 0; i < n; ++i)
            {
                q.Push(new int[] { 0, i, heightMap[0, i] });
                Debug.Print(heightMap[0, i].ToString());

                q.Push(new int[] { m - 1, i, heightMap[m - 1, i] });
                Debug.Print(heightMap[m - 1, i].ToString());

                visitied[0, i] = visitied[m - 1, i] = true;
            }

            while (q.Count > 0)
            {
                var cell = q.Pop();
                Debug.Print("Dequeue:{0}",cell[2]);

                for (var i = 0; i < 4; ++i)
                {
                    var x = cell[0] + directions[i, 0];
                    var y = cell[1] + directions[i, 1];
                    if (x < 0 || x == m || y < 0 || y == n || visitied[x, y]) continue;
                    total += Math.Max(0, cell[2] - heightMap[x, y]);
                    //Debug.Print("{0}:{1}:{2}", cell[0], cell[1], cell[2]);
                    //Debug.Print("{0},{1}[{2}],{3}", x, y, heightMap[x, y], total);
                    q.Push(new int[] { x, y, Math.Max(cell[2], heightMap[x, y]) });
                    Debug.Print(Math.Max(cell[2], heightMap[x, y]).ToString());

                    visitied[x, y] = true;
                }
            }

            return total;
        }

        public int TrapRainWater1(int[,] heightMap)
        {
            var total = 0;
            var m = heightMap.GetLength(0);
            var n = heightMap.GetLength(1);
            var visitied = new bool[m, n];
            var q = new LeetCode.DataStructure.BinaryHeap<int[]>((a, b) => a[2] - b[2]);
            for (var i = 0; i < m; ++i)
            {
                q.Enqueue(new int[] { i, 0, heightMap[i, 0] });
                q.Enqueue(new int[] { i, n - 1, heightMap[i, n - 1] });
                visitied[i, 0] = visitied[i, n - 1] = true;// don't forget to set visited when init the queue
            }

            for (var i = 0; i < n; ++i)
            {
                q.Enqueue(new int[] { 0, i, heightMap[0, i] });
                q.Enqueue(new int[] { m - 1, i, heightMap[m - 1, i] });
                visitied[0, i] = visitied[m - 1, i] = true;
            }

            while (q.Count > 0)
            {
                var cell = q.Dequeue();
                for (var i = 0; i < 4; ++i)
                {
                    var x = cell[0] + directions[i, 0];
                    var y = cell[1] + directions[i, 1];
                    if (x < 0 || x == m || y < 0 || y == n || visitied[x, y]) continue;
                    total += Math.Max(0, cell[2] - heightMap[x, y]);
                    Debug.Print("{0}:{1}:{2}", cell[0], cell[1], cell[2]);
                    Debug.Print("{0},{1}[{2}],{3}", x, y, heightMap[x, y], total);

                    q.Enqueue(new int[] { x, y, Math.Max(cell[2], heightMap[x, y]) });
                    visitied[x, y] = true;
                }
            }

            return total;
        }

        public int TrapRainWaterWrong(int[,] heightMap)
        {
            var m = heightMap.GetLength(0);
            var n = heightMap.GetLength(1);

            var highest = new int[m, n, 4];

            for (var i = 0; i < m; ++i)
            {
                highest[i, 0, 0] = heightMap[i, 0];
                highest[i, n - 1, 1] = heightMap[i, n - 1];
                // scan left to right  and right to left for reach row.
                for (var j = 1; j < n; ++j)
                {
                    highest[i, j, 0] = Math.Max(highest[i, j - 1, 0], heightMap[i, j]);
                    highest[i, n - j - 1, 1] = Math.Max(highest[i, n - j, 1], heightMap[i, n - j - 1]);
                }
            }

            for (var i = 0; i < n; ++i)
            {
                highest[0, i, 2] = heightMap[0, i];
                highest[m - 1, i, 3] = heightMap[m - 1, i];
                //scan rows
                for (var j = 1; j < m; ++j)
                {
                    highest[j, i, 2] = Math.Max(highest[j - 1, i, 2], heightMap[j, i]);
                    highest[m - j - 1, i, 3] = Math.Max(highest[m - j, i, 3], heightMap[m - j - 1, i]);
                }
            }
            var total = 0;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; ++j)
                {
                    var min = Math.Min(highest[i, j, 0], highest[i, j, 1]);
                    min = Math.Min(min, Math.Min(highest[i, j, 2], highest[i, j, 3]));
                    total += min - heightMap[i, j];
                }
            }


            return total;
        }
    }
}
