using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.DataStructure.LeetCodeDataStructures;
namespace LeetCode.Problems.MathProblems
{
    public class MaxPointsOnALine
    {
        public int MaxPoints(Point[] points)
        {
            if (points.Length <= 1) return points.Length;
            var max = 0;
            var maxIndex = 0;

            var maxkey = new string[points.Length - 1];
            var maxHash = new HashSet<int>[points.Length - 1];
            for (var i = 0; i < points.Length - 1; i++)
            {
                var dict = new Dictionary<string, HashSet<int>>();
                var same = 1;
                var sofar = 0;
                var p1 = points[i];
                for (var j = i + 1; j < points.Length; j++)
                {
                    var key = "";

                    var p2 = points[j];

                    if (p1.x == p2.x) // vertial to axis - x
                    {
                        if (p1.y == p2.y)
                        {
                            same++;
                            continue;
                        }
                        key = p1.x.ToString();
                    }
                    else
                    {
                        key = Reduction(p2.y - p1.y, p2.x - p1.x);
                    }
                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new HashSet<int>();
                    }

                    dict[key].Add(j);
                    //dict[key]++;
                    sofar = Math.Max(dict[key].Count, sofar);

                    if (dict[key].Count == sofar)
                    {
                        maxHash[i] = dict[key];
                        maxkey[i] = key;
                    }
                }
                sofar += same;
                max = Math.Max(max, sofar);
                if (sofar == max) maxIndex = i;
            }
            Console.WriteLine("{0},{1}", maxkey[maxIndex], maxIndex);
            Console.WriteLine(string.Join(",", maxHash[maxIndex]));
            return max;
        }
        public int MaxPoints1(Point[] points)
        {
            if (points.Length <= 1) return points.Length;
            var max = 0;
            var maxIndex = 0;

            var maxkey = new string[points.Length - 1];
            var maxHash = new HashSet<int>[points.Length - 1];

            for (var i = 0; i < points.Length - 1; i++)
            {
                var dict = new Dictionary<string, HashSet<int>>();
                for (var j = i + 1; j < points.Length; j++)
                {
                    var key = "";
                    var p1 = points[i];
                    var p2 = points[j];
                    if (p1.x == p2.x) // vertial to axis - x
                    {
                        key = "infinity," + p1.x.ToString();
                    }
                    else
                    {

                        var k = Reduction(p2.y - p1.y, p2.x - p1.x);
                        var b = Reduction(p1.y * (p2.x - p1.x) - (p2.y - p1.y) * p1.x, p2.x - p1.x);
                        key = string.Format("{0},{1}", k, b);
                    }
                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new HashSet<int>();
                    }
                    dict[key].Add(i);
                    dict[key].Add(j);
                    //Console.WriteLine("{0},{1}:{2}", i, j, key);
                    max = Math.Max(max, dict[key].Count);

                    if (dict[key].Count == max)
                    {
                        maxIndex = i;
                        maxkey[i] = key;
                        maxHash[i] = dict[key];
                    }
                }
            }
            Console.WriteLine("{0},{1}", maxkey[maxIndex], maxIndex);
            Console.WriteLine(string.Join(",", maxHash[maxIndex]));
            return max;
        }

        public int GCD(int x, int y)
        {
            if (x == 0) return y;
            var sign = (x > 0) ^ (y > 0) ? -1 : 1;
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (y != 0)
            {
                var c = x % y;
                x = y;
                y = c;
            }

            return sign * x;
        }

        public string Reduction(int x, int y)
        {
            if (y == 0) return string.Format("{0}/{1}", x, 0);
            var gcd = GCD(x, y);

            return string.Format("{0}/{1}", x / gcd, y / gcd);
        }
    }
}
