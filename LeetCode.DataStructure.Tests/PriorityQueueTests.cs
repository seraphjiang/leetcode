using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SA = LeetCode.DataStructure.Standalone;
using DS = LeetCode.DataStructure;
using v2 = LeetCode.DataStructure.LeetCodeDataStructures;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace LeetCode.DataStructure.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void Test_PriorityQueue_Top()
        {
            var max = int.MinValue;
            var n = new Random(DateTime.Now.Second);
            var q = new SA.PriorityQueue<int>();
            for (var i = 0; i < 10; i++)
            {
                var x = n.Next(100);
                max = Math.Max(x, max);
                q.Push(x);
            }

            Assert.AreEqual(max, q.Top());
        }

        [TestMethod]
        public void Test_PriorityQueue_1()
        {
            var q = new SA.PriorityQueue<int>();
            q.Push(8);
            q.Push(6);
            q.Push(4);

            var list = new List<int>(q.heap.Take(3));
            var expected = new List<int> { 8, 6, 4 };
            Assert.IsTrue(expected.SequenceEqual(list));
        }

        [TestMethod]
        public void Test_PriorityQueue_2()
        {
            var q = new SA.PriorityQueue<int>();
            q.Push(8);
            q.Push(4);
            q.Push(6);

            var list = new List<int>(q.heap.Take(3));
            var expected = new List<int> { 8, 4, 6 };
            Assert.IsTrue(expected.SequenceEqual(list));
        }

        [TestMethod]
        public void Test_PriorityQueue_BS()
        {
            var q = new BinaryHeap<int>((a, b) => a - b);
            q.Enqueue(8);
            q.Enqueue(4);
            q.Enqueue(6);

            var list = q.list;
            var expected = new List<int> { 8, 4, 6 };
            Assert.IsTrue(expected.SequenceEqual(list));
        }

        [TestMethod]
        public void Test_PriorityQueue_V2()
        {
            var q = new v2.PriorityQueue<int>();
            q.Push(8);
            q.Push(4);
            q.Push(6);

            var list = new List<int>(q.heap.Take(3));
            var expected = new List<int> { 4, 8, 6 };
            Assert.IsTrue(expected.SequenceEqual(list));
            q.Pop();
            list = new List<int>(q.heap.Take(2));
            expected = new List<int> { 6, 8 };
            Assert.IsTrue(expected.SequenceEqual(list));
        }
        [TestMethod]
        public void Test_PriorityQueue_V2_2()
        {
            var q2 = new v2.PriorityQueue<int>();
            foreach (var n in new int[] { 12, 13, 12, 13, 12, 12, 12, 13, 13, 12, 13, 13, 13, 1, 13, 12, 13 })
            //foreach (var n in new int[] { 12, 13, 12, 13,  })
            {
                q2.Push(n);
            }

            while (q2.Count > 0)
            {
                var q = q2.Pop();
                Debug.Print(q.ToString());
            }
        }
        [TestMethod]
        public void Test_PriorityQueue_V2_3()
        {
            var q2 = new v2.PriorityQueue<int>();
            var input = new int[,] {
               {13,16,15,18,15,15},
               {14, 1, 8, 9, 7, 9},
               {19, 5, 4, 2, 5, 10},
               {13, 1, 7, 9, 10, 3},
               {17, 7, 5, 10, 6, 1},
               {15, 9, 8, 2, 8, 3 } };
            int m = input.GetLength(0), n = input.GetLength(1);
            for (var i = 0; i < m; i++)
            {
                q2.Push(input[i, 0]);
                q2.Push(input[i, n - 1]);
            }
            for (var i = 0; i < n; i++)
            {
                q2.Push(input[0, i]);
                q2.Push(input[m - 1,i]);
            }

            while (q2.Count > 0)
            {
                var q = q2.Pop();
                Debug.Print(q.ToString());
            }
        }

        [TestMethod]
        public void Test_PriorityQueue_V2_4()
        {
            var q2 = new v2.PriorityQueue<int>();
            foreach (var n in new int[] {13,13,15,15,14,15,13,15 })
            {
                q2.Push(n);
            }
            var pre = q2.Top();
            while (q2.Count > 0)
            {
                var q = q2.Pop();
                Debug.Print(q.ToString());
                Assert.IsTrue(pre <= q);
                pre = q;
            }
        }
        
        [TestMethod]
        public void Test_PriorityQueue_V2_1()
        {
            var input = new int[,] {
                { 12, 13, 1, 12 },
                { 13, 4, 13, 12 },
                { 13, 8, 10, 12 },
                { 12, 13, 12, 12 },
                { 13, 13, 13, 13 } };
            var q1 = new LeetCode.DataStructure.BinaryHeap<int[]>((a, b) => a[2] - b[2]);
            var q2 = new v2.PriorityQueue<int[]>(16, Comparer<int[]>.Create((a, b) => a[2] - b[2]));
            int m = input.GetLength(0), n = input.GetLength(1);

            for(var i=0;i< m; i++)
            {
                for(var j=0;j< n; j++)
                {
                    var item = new int[] { i,j,input[i,j]};
                    q1.Enqueue(item);
                    q2.Push(item);
                    Assert.AreEqual(q1.Seek()[2], q2.Top()[2]);
                }
            }

        }
    }
}
