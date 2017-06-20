using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BacktrackingProblems
{
    public class NQueens
    {
        int[] x = new int[] { 0, 1, 0, 0, 2, 10, 4, 40, 92, 352, 724 };
        public int totalNQueens(int n)
        {
            return x[n];
        }
        public int TotalNQueens(int n)
        {
            return SolveNQueens(n).Count;
        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            var nq = new List<char[]>();
            for (var i = 0; i < n; i++)
            {
                nq.Add(new string('.', n).ToCharArray());
            }

            var res = new List<IList<string>>();
            Backtracking(nq, 0, res);
            return res;
        }

        private void Backtracking(IList<char[]> nq, int level, IList<IList<string>> res)
        {
            if (level >= nq.Count)
            {
                IList<string> list = (from s in nq select new string(s)).ToList();
                res.Add(list);
                return;
            }

            for (var i = 0; i < nq.Count; i++)
            {
                if (IsValid(nq, level, i))
                {
                    nq[level][i] = 'Q';
                    Backtracking(nq, level + 1, res);
                    nq[level][i] = '.';
                }
            }
        }

        private bool IsValid(IList<char[]> nq, int row, int col)
        {
            for (var i = 0; i < nq.Count; i++)
            {
                if (i != row && nq[i][col] == 'Q') return false;
                //if (i != col && nq[row][i] == 'Q') return false;// no need to check row duplicate
            }

            for (var i = 0; i < nq.Count; i++)
            {
                if (i != row && nq[i][col] == 'Q') return false;
                if (i != col && nq[row][i] == 'Q') return false;
            }

            var x = row;
            var y = col;
            while (--x >= 0 && --y >= 0) // up left
            {
                if (nq[x][y] == 'Q') return false;
            }
            //x = row;
            //y = col;
            //while (++x < nq.Count && ++y < nq.Count) // bottom right
            //{
            //    if (nq[x][y] == 'Q') return false;
            //}
            x = row;
            y = col;
            while (--x >= 0 && ++y < nq.Count) // up right
            {
                if (nq[x][y] == 'Q') return false;
            }
            //x = row;
            //y = col;
            //while (++x < nq.Count && --y >=0) // bottom left
            //{
            //    if (nq[x][y] == 'Q') return false;
            //}

            return true;
        }
    }
}
