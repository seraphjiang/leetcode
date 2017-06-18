using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.QTC
{
    public class WaterFallShortestPath
    {
        public class Point
        {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        public class Slab
        {
            public int X;
            public int Y;
            public int Length;
        }
        public int GetPath(Point start, Slab[] slabs)
        {
            Array.Sort(slabs, (a, b) => { return b.Y.CompareTo(a.Y); });
            return dfs(start, slabs, 0, 0) + start.Y;
        }

        public int dfs(Point start, Slab[] slabs, int level, int total)
        {
            if (level == slabs.Length)
            {
                return total;
            }
            var cur = slabs[level];
            if ((slabs[level].X < start.X) && (slabs[level].X + slabs[level].Length < start.X))
            {
                var left = start.X - cur.X + dfs(new Point(cur.X, cur.Y), slabs, level + 1, total + (start.X - cur.X));
                var right = cur.X + cur.Length - start.X + dfs(new Point(cur.X + cur.Length, cur.Y), slabs, level + 1, total + (cur.X + cur.Length - start.X));

                return Math.Min(left, right);
            }
            
            return dfs(start, slabs, level + 1, total);
        }
    }
}