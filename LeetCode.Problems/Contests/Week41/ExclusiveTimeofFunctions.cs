using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week41
{
    public class ExclusiveTimeofFunctions
    {
        public int[] exclusiveTime(int n, List<String> logs)
        {
            // separate time to several intervals, add interval to their function
            int[] result = new int[n];
            Stack<int> st = new Stack<int>();
            int pre = 0;
            // pre means the start of the interval
            foreach (var log  in logs)
            {
                string[] arr = log.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr[1].Equals("start"))
                {
                    if (st.Count>0) result[st.Peek()] += int.Parse(arr[2]) - pre;
                    // arr[2] is the start of next interval, doesn't belong to current interval.
                    st.Push(int.Parse(arr[0]));
                    pre = int.Parse(arr[2]);
                }
                else
                {
                    result[st.Pop()] += int.Parse(arr[2]) - pre + 1;
                    // arr[2] is end of current interval, belong to current interval. That's why we have +1 here
                    pre = int.Parse(arr[2]) + 1;
                    // pre means the start of next interval, so we need to +1
                }
            }
            return result;
        }
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var times = new int[n];
            var stack = new Stack<TimeStamp>();
            var list = new List<TimeStamp>();
            list.Add(new TimeStamp(logs[0]));
            stack.Push(list[0]);
            for (var i = 1; i < logs.Count; i++)
            {
                list.Add(new TimeStamp(logs[i]));
                if (list[i - 1].IsStart && list[i].IsEnd)
                {
                    times[list[i].Id] += list[i].TimeTick - list[i - 1].TimeTick + 1;
                }
                else if (list[i].IsStart && list[i - 1].IsStart)
                {
                    times[list[i - 1].Id] += list[i].TimeTick - list[i - 1].TimeTick;
                }
                else if (list[i].IsEnd && list[i - 1].IsEnd)
                {
                    times[list[i].Id] += list[i].TimeTick - list[i - 1].TimeTick;
                }
                else
                {
                    if (stack.Count > 0)
                        times[stack.Peek().Id] += list[i].TimeTick - list[i - 1].TimeTick - 1;
                }

                if (list[i].IsStart)
                {
                    stack.Push(list[i]);
                }
                else
                {
                    stack.Pop();
                }
            }

            return times;
        }

        public class TimeStamp
        {
            public int Id;
            public int TimeTick;
            public bool IsStart;
            public bool IsEnd;
            public TimeStamp(string ts)
            {
                var arr = ts.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                Id = int.Parse(arr[0]);
                IsStart = arr[1].Equals("start");
                IsEnd = !IsStart;
                TimeTick = int.Parse(arr[2]);
            }
        }
    }
}
