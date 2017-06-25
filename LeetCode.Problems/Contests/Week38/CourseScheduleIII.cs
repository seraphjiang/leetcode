using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;
namespace LeetCode.Problems.Contests.Week38
{
    public class CourseScheduleIII
    {

        public int ScheduleCourse(int[,] courses)
        {
            var c = courses.To2D();
            Array.Sort(c, Comparer<int[]>.Create((a, b) => a[1] == b[1] ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1])));
            courses = c.To2D();
            var sl = new List<int>();
            
            var n = courses.GetLength(0);
            var timeTillNow = 0;
            for (var i = 0; i < n; ++i)
            {
                if (timeTillNow + courses[i, 0] <= courses[i, 1]) // valid
                {
                    Insert(sl, courses[i, 0]);
                    timeTillNow += courses[i, 0];
                }
                else if (sl.Last() > courses[i, 0]) // we already sorted end time, if time cost is small the pre, always better to switch
                {
                    timeTillNow += courses[i, 0] - sl.Last();
                    sl.RemoveAt(sl.Count - 1);
                    Insert(sl, courses[i, 0]);
                }
                // time cost even big , ignore.
            }

            return sl.Count;
        }

        public void Insert(List<int> l, int val)
        {
            var index = l.BinarySearch(val);
            index = index < 0 ? ~index : index;
            l.Insert(index, val);
        }
 
        int max = 0;
        public int ScheduleCourseDfsTLE(int[,] courses)
        {
            //var c = courses.To2D();
            //Array.Sort(courses, Comparer<int[]>.Create((a, b) => a[1] == b[1] ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1])));
            //courses = c.To2D();
            var n = courses.GetLength(0);
            var visitied = new bool[n];
            for (var i = 0; i < n; i++)
            {
                visitied[i] = true;
                max = Math.Max(max, dfs(courses, visitied, i, 0, 0));
                visitied[i] = false;
            }

            return max;
        }

        public int dfs(int[,] courses, bool[] visitied, int index, int end, int count)
        {
            if (count > max) max = count;
            if (max == visitied.Length) return visitied.Length;

            end += courses[index, 0];
            if (end > courses[index, 1]) return count;

            count++;
            var m = count;
            for (var i = 0; i < visitied.Length; ++i)
            {
                if (visitied[i] || i == index) continue;

                visitied[i] = true;
                m = Math.Max(m, dfs(courses, visitied, i, end, count));
                visitied[i] = false;
            }

            return m;
        }
    }
}
