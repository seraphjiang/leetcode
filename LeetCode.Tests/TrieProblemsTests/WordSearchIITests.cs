using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.TrieProblems;
using Commons;
using System.Collections.Generic;

namespace LeetCode.Tests.TrieProblemsTests
{
    [TestClass]
    public class WordSearchIITests
    {
        [TestMethod]
        public void Test_WordSearchII1()
        {
            var o = new WordSearchII();
            var bs = new string[] { "oaan", "etae", "ihkr", "iflv" };
            var board = new char[bs.Length, bs[0].Length];

            for(var i = 0; i < board.GetLength(0); ++i)
            {
                for(var j = 0; j < board.GetLength(1); ++j)
                {
                    board[i, j] = bs[i][j];
                }
            }
           
            var expect = new List<string> { "oath", "eat" };
            Assert.IsTrue(expect.SetEquals(o.FindWords(board, new string[] { "oath", "pea", "eat", "rain" })));
        }
    }
}
