using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.DesignProblems;

namespace LeetCode.Tests.DesignProblemsTests
{
    [TestClass]
    public class LFUCacheTests
    {
        [TestMethod]
        public void Test_LFUCache1()
        {
            //["LFUCache","put","put","get","put","get","get","put","get","get","get"]
            //[[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]
            var o = new LFUCache(2);
            o.Put(1, 2);
            o.Put(2, 2);
            o.Get(2);
            o.Put(3,3);
            o.Get(2);
            o.Get(3);
            o.Put(4, 4);
            o.Get(1);
            o.Get(3);
            o.Get(4);
        }
    }
}
