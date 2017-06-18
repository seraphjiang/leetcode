using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week37
{
    public class TaskSchedulerProblem
    {
        public int LeastInterval(char[] tasks, int n)
        {
            int[] counter = new int[26];
            int max = 0;
            int maxCount = 0;
            foreach (var task in tasks)
            {
                counter[task - 'A']++;
                if (max == counter[task - 'A'])
                {
                    maxCount++;
                }
                else if (max < counter[task - 'A'])
                {
                    max = counter[task - 'A'];
                    maxCount = 1;
                }
            }

            int partCount = max - 1;
            int partLength = n - (maxCount - 1);
            int emptySlots = partCount * partLength;
            int availableTasks = tasks.Length - max * maxCount;
            int idles = Math.Max(0, emptySlots - availableTasks);

            return tasks.Length + idles;
        }

        public int LeastInterval1(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;
            if (tasks.Length == 0) return 0;

            var c = new int[26];
            foreach(var t in tasks)
            {
                c[t - 'A']++;
            }

            Array.Sort(c);
            var res = 0;
            var cycle = n + 1;
            while (c[25] > 1)
            {
                var maxRemove = c[25];// n>25, 1 cycle exce all. n==0, total Length, n==1, 
                res = (c[25] - 1) * cycle;
                // ideally if n is large enough that 25 which is max amount of task type. it could exec all type in one cycle
                // as long as n is large than tasks.count that work
                // in the case, n is less than tasks.count
                // e.g. n = 4, we have 15 task type. all task has same ammount.
                // so, first 1 cycle, it take (4+1) out of task list., then recursive run
                //----
                // it needs 15/(4+1) = 3 full cycle to finish


                 
            }

            return res;
        }

        public int LeastIntervalWrong(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;
            var dict = new Dictionary<char, int>();
            foreach (var t in tasks)
            {
                if (!dict.ContainsKey(t)) dict[t] = 0;
                dict[t]++;
            }
            var list = new List<int>();
            foreach (var kv in dict)
            {
                list.Add(kv.Value);
            }
            list.Sort();

            var total = 0;
            while (list.Count > 0)
            {
                if (list.Count > n)
                {
                    total += list[list.Count - (n +1 )] * (n + 1);
                    var c = list.Count;
                    for (var i = list.Count - 1; i >= (c - (n +1)); i--)
                    {
                        list[i] -= list[c - (n+1)];
                        if (list[i] == 0) list.RemoveAt(i);
                    }
                }
                else
                {
                    var c = list.Count;
                    total += list[0] * (n + 1);
                    for (var i = c - 1; i >= 0; i--)
                    {
                        list[i] -= list[0];
                        if (list[i] == 0) list.RemoveAt(i);
                    }

                    if (list.Count == 0)
                    {
                        total -= (n + 1 - c);
                    }
                }

                list.Sort();
            }

            return total;
        }
    }
}
