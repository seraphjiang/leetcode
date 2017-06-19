using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week37
{
    public class TaskSchedulerProblem
    {
        /// <summary>
        /// https://discuss.leetcode.com/topic/92966/java-o-n-time-o-1-space-1-pass-no-sorting-solution-with-detailed-explanation/2
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
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

            int partCount = max - 1;    // how many party with empty slots
            int partLength = n - (maxCount - 1);    // let's say, there are multple task type , all length equal max length. 
                                                    // part lenth = cycle length - num of max tasks count = (n+1) - maxCount
                                                    // in the case, max count is large than or equals to cycle length
                                                    // parth length could be negative.
                                                    // part length here means length of empty slot in a cycle
            int emptySlots = partCount * partLength;    // part count * part Length = total avaliable empty slots.
            int availableTasks = tasks.Length - max * maxCount; // total task ammount - (total num of task which it has max ammout of task)
                                                                //  the remain is total non-max task left.
                                                                // this should always large than or equals to zero
            int idles = Math.Max(0, emptySlots - availableTasks); //
                                             // idles = emptys - available 
                                             // = partCount*partLength - (task.Length - max * maxCount)
                                             // = (max-1)* (n+1 - maxCount) - (task.Length - max * maxCount)

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
