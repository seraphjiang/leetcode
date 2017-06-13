using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    /// <summary>
    /// https://www.hackerrank.com/contests/iit-guwahati-placement-preparation-test-02/challenges/largest-island
    /// You are given a map in the form of a rectangular grid. In this map, a 1 represents a piece of land and 0 represents water. A group of connected 1's forms an island. Two 1's are connected if they are adjacent on the grid (You can consider up, down, left, right as well as diagonal points to be adjacent). Your job is to find the area of the largest island.
    /// </summary>
    public class LargestIsland
    {
        static string[] islands;
        static bool[,] visitied;
        static int n;
        static int m;
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //var line1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var tr = new StreamReader("LargestIsland.txt");
            var line1 = tr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(line1[0]);
            m = int.Parse(line1[1]);

            islands = new string[n];
            visitied = new bool[n, m];
            for (var i = 0; i < n; i++)
            {
                //var lines = Console.ReadLine();
                var lines = tr.ReadLine();
                islands[i] = lines;
            }
            var max = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (visitied[i, j] || islands[i][j] == '0') continue;
                    max = Math.Max(max, bfs(i, j));
                }
            }

            Console.WriteLine(max);
        }

        //static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //    var line1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    var n = int.Parse(line1[0]);
        //    var m = int.Parse(line1[1]);

        //    var islands = new string[n];
        //    var visitied = new bool[n, m];
        //    for (var i = 0; i < n; i++)
        //    {
        //        var lines = Console.ReadLine();
        //        islands[i] = lines;
        //    }
        //    var max = 0;
        //    for (var i = 0; i < n; i++)
        //    {
        //        for (var j = 0; j < m; j++)
        //        {
        //            if (visitied[i, j] || islands[i][j] == '0') continue;
        //            max = Math.Max(max, dfs(islands, visitied, i, j, n, m));
        //        }
        //    }

        //    Console.WriteLine(max);
        //}

        static int dfs(string[] islands, bool[,] visitied, int x, int y, int n, int m)
        {
            if (visitied[x, y]) return 0;

            visitied[x, y] = true;
            var directions = new int[,]{
            {1,0}, {-1,0},{0,1},{0,-1},{1,1},{-1,-1},{1,-1},{-1,1}
        };
            var count = 1;
            for (var i = 0; i < 8; i++)
            {
                var r = x + directions[i, 0];
                var c = y + directions[i, 1];

                if (r < 0 || r >= n || c < 0 || c >= m || visitied[r, c] || islands[r][c] == '0') continue;

                count += dfs(islands, visitied, r, c, n, m);
            }

            return count;
        }

        static int bfs(int x, int y)
        {
            if (visitied[x, y]) return 0;

            visitied[x, y] = true;
            var directions = new int[,]{
                {1,0}, {-1,0},{0,1},{0,-1},{1,1},{-1,-1},{1,-1},{-1,1}
            };
            var count = 1;
            var q = new Queue<Tuple<int, int>>();//
            var filename = Path.GetRandomFileName();
            //q.Enqueue(Tuple.Create(x, y));
            using (var write = File.AppendText(filename))
            {
                write.WriteLine(string.Format("{0},{1}", x, y));
                write.Close();
            }
            var qCount = 1;
            while (qCount > 0)
            {
                var li = File.ReadAllLines(filename);
                var node = li[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var newLines = li.Skip(1).Take(li.Length - 1).ToArray();
                File.WriteAllLines(filename, newLines);
                count++;
                qCount = li.Length - 1;
                var x0 = int.Parse(node[0]);
                var y0 = int.Parse(node[1]);
                //visitied[x0, y0] = true;
                for (var i = 0; i < 8; i++)
                {
                    var r = x0 + directions[i, 0];
                    var c = y0 + directions[i, 1];
                    if (r < 0 || r >= n || c < 0 || c >= m || visitied[r, c] || islands[r][c] == '0') continue;
                    //write.WriteLine(string.Format("{0},{1}", r, c));
                    //q.Enqueue(Tuple.Create(r, c));
                    visitied[r, c] = true;
                    using (var liwr = File.AppendText(filename))
                    {
                        liwr.WriteLine(string.Format("{0},{1}", r, c));
                        liwr.Close();
                        qCount++;
                    }
                }
            }

            return count;
        }
    }
}
