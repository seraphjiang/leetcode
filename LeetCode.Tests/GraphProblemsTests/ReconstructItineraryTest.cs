using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.GraphProblems;
using System.Linq;
using System.Collections.Generic;

namespace LeetCode.Tests.GraphProblemsTests
{
    [TestClass]
    public class ReconstructItineraryTest
    {
        [TestMethod]
        public void Test_ReconstructItinerary1()
        {
            var o = new ReconstructItinerary();
            var input = new string[,]
            {
                { "JFK", "SFO"},{"JFK", "ATL"},{"SFO", "ATL"},{"ATL", "JFK"},{"ATL", "SFO"}
            };
            var expected = new List<string> { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" };
            Assert.IsTrue(expected.SequenceEqual(o.FindItinerary(input)));
        }
    }
}
