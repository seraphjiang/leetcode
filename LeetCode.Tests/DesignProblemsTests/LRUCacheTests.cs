using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DesignProblems;

namespace LeetCode.Tests.DesignProblemsTests
{
    [TestClass]
    public class LRUCacheTests
    {
        [TestMethod]
        public void Test_LRU1()
        {
            var o = new LRUCache(2);
            o.Put(1, 1);
            o.Put(2, 2);
            o.Get(1);
            o.Put(3, 3);
            o.Get(2);
            o.Put(4, 4);
            o.Get(1);
            o.Get(3);
            o.Get(4);

            //o.Put(2, 6);
            //o.Put(1, 5);
            //o.Put(1, 2);
        }
    }
}
