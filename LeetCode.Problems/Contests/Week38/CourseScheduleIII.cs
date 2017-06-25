using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week38
{
    public class CourseScheduleIII
    {
        int max = 0;
        public int ScheduleCourse(int[,] courses)
        {
            //Array.Sort(courses, (a, b) => { return 1; });
            //Array.Sort(courses, (a, b) => { return b.CompareTo(a); });

            var n = courses.GetLength(0);
            var visitied = new bool[n];
            for (var i = 0; i < n; i++)
            {
                dfs(courses, visitied, i, 0);
            }

            return max;
        }

        public void dfs(int[,] courses, bool[] visitied, int i, int count)
        {
            if (count > max) max = count;
            if (max == visitied.Length) return;

            if (visitied[i]) return;



        }
    }
}
