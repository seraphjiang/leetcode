using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week34
{
    public class MinimumIndexSumofTwoLists
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var dict = new Dictionary<string, int>();
            for (var i = 0; i < list1.Length; i++)
            {
                dict[list1[i]] = i;
            }
            var list = new List<string>();
            var minSum = int.MaxValue;
            for (var j = 0; j < list2.Length; j++)
            {
                if (dict.ContainsKey(list2[j]))
                {
                    var sum = dict[list2[j]] + j;
                    if (sum < minSum)
                    {
                        minSum = sum;
                        list = new List<string>();
                    }

                    if (minSum == sum)
                    {
                        list.Add(list2[j]);
                    }
                }
            }
            return list.ToArray();
        }
    }
}
