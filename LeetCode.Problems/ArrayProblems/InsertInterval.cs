using LeetCode.DataStructure.LeetCodeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.ArrayProblems
{
    public class InsertInterval
    {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            if ((intervals == null || intervals.Count == 0) && newInterval == null) return intervals;
            if (intervals == null)
            {
                intervals = new List<Interval> { newInterval }; return intervals;
            }
            var ret = new List<Interval>(intervals);
            ret.Add(newInterval);
            for (var i = ret.Count - 1; i > 0; i--)
            {
                var tail = ret[i];
                var pre = ret[i - 1];
                if (tail.start > pre.end)
                {
                    break;
                }
                else if (tail.start == pre.end)
                {
                    pre.end = tail.end;
                    ret.RemoveAt(i);
                    break;
                }
                else if (tail.end < pre.start)
                {
                    var tmp = tail;
                    ret[i] = ret[i - 1];
                    ret[i - 1] = tail;
                }
                else // tail.Start < pre.End , has interaction
                {
                    pre.start = Math.Min(tail.start, pre.start);
                    pre.end = Math.Max(tail.end, pre.end);
                    ret.RemoveAt(i);
                }
            }

            return ret;
        }
    }
}
