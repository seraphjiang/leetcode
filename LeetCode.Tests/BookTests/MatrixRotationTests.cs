using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Book.Examples;

namespace LeetCode.Tests.BookTests
{
    [TestClass]
    public class MatrixRotationTests
    {
        [TestMethod]
        public void Test_MatrixRotation_1()
        {
            var o = new MatrixRotation();
            var matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            var res = MatrixRotation.ClockwiseRotate90Degree(matrix);

            Assert.AreEqual(res.GetLength(0), matrix.GetLength(1));
        }
    }
}
