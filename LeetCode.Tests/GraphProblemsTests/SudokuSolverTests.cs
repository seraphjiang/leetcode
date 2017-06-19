using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.GraphProblems;
using System.Diagnostics;

namespace LeetCode.Tests.GraphProblemsTests
{
    [TestClass]
    public class SudokuSolverTests
    {
        [TestMethod]
        public void Test_SudokuSolver_1()
        {
            var input = new char[][]
            {
                "..9748...".ToCharArray(),
                "7........".ToCharArray(),
                ".2.1.9...".ToCharArray(),
                "..7...24.".ToCharArray(),
                ".64.1.59.".ToCharArray(),
                ".98...3..".ToCharArray(),
                "...8.3.2.".ToCharArray(),
                "........6".ToCharArray(),
                "...2759..".ToCharArray()
            };

            var board = new char[9, 9];
            for(var i = 0; i < 9; i++)
            {
                for(var j = 0; j < 9; j++)
                {
                    board[i, j] = input[i][j];
                }
            }
            var o = new SudokuSolver();
            o.SolveSudoku(board);

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    Debug.Write(board[i, j]);
                }
                Debug.WriteLine("");
            }
        }
    }
}
