using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.ArrayProblems;

namespace LeetCode.Tests.ArrayProblemsTests
{
    [TestClass]
    public class MedianofTwoSortedArraysTests
    {
        [TestMethod]
        public void Test_FindMedianSortedArrays1()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2, o.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
        }

        [TestMethod]
        public void Test_FindMedianSortedArrays2()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2.5, o.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
        }

        [TestMethod]
        public void Test_FindMedianSortedArrays3()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2, o.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void Test_FindMedianSortedArrays4()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(1, o.FindMedianSortedArrays(new int[] { 1 }, new int[] { 1 }));
        }

        [TestMethod]
        public void Test_FindMedianSortedArrays5()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2, o.FindMedianSortedArrays(new int[] { 3 }, new int[] { 1, 2 }));
        }
        [TestMethod]
        public void Test_FindMedianSortedArrays6()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2.5, o.FindMedianSortedArrays(new int[] { 1 }, new int[] { 2, 3, 4 }));
        }
        [TestMethod]
        public void Test_FindMedianSortedArrays7()
        {
            var o = new MedianofTwoSortedArrays();
            Assert.AreEqual(2.5, o.FindMedianSortedArrays(new int[] { 2 }, new int[] { 1, 3, 4 }));
        }
    }
}
