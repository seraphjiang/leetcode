using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.GraphProblems
{
    public class SudokuSolver
    {
        public void SolveSudoku(char[,] board)
        {
            Solve(board, 0, 0);
        }

        public bool Solve(char[,] board, int x, int y)
        {
            if (x == 8 && y == 8 && board[x, y] != '.') return IsValid(board, x, y);

            if (board[x, y] == '.')
            {
                for (var i = 1; i < 10; i++)
                {
                    board[x, y] = (char)('0' + i);
                    if (Solve(board, x, y))
                    {
                        return true;
                    }
                    board[x, y] = '.';
                }
            }
            else
            {
                if (!IsValid(board, x, y)) return false;
                if (y < 8)
                {
                    if (Solve(board, x, y + 1)) return true;
                }
                else if (y == 8 && x < 8)
                {
                    if (Solve(board, x + 1, 0)) return true;
                }
            }

            return false;
        }

        private bool IsValid(char[,] board, int x, int y)
        {
            var r0 = (x / 3) * 3;
            var c0 = (y / 3) * 3;
            if (board[x, y] == '.') return false;
            for (var i = 0; i < 9; i++)
            {
                if (i != y && board[x, i] == board[x, y]) return false;
                if (i != x && board[i, y] == board[x, y]) return false;

                var r = r0 + i / 3;
                var c = c0 + i % 3;

                if (r != x && c != y && board[r, c] == board[x, y]) return false;
            }

            return true;
        }
    }
}
