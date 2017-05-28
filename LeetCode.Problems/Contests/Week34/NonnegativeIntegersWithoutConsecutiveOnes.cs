using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week34
{
    public class NonnegativeIntegersWithoutConsecutiveOnes
    {
        Dictionary<int, int> cache = new Dictionary<int, int>();
        public int FindIntegers(int num)
        {
            if (num < 3) return num + 1;

            if (cache.ContainsKey(num)) return cache[num];
            var binary = Convert(num);
            var count = 0;
            if (binary[1] == 1)
            {
                //var mask = (1 << (binary.Count - 2)) - 1;
                //var rest = num & mask;
                //count += rest + 1;// 11,xxx ignore all.
                var next = (binary.Count > 2 ? (3 << binary.Count - 2) : num) - 1;
                count += FindIntegers(next); // count 11,000-1;
            }
            else
            {
                var mask = (1 << (binary.Count - 1)) - 1;
                var rest = num & mask;
                count += FindIntegers(rest);// 10xxx; count all xxx-1; because 10,000 cannot be counted
                count += FindIntegers((1 << (binary.Count - 1)) - 1); // count 1,000-1 which is 111
            }
            cache[num] = count;
            Console.WriteLine("{0},{1}", num, count);
            return count;
        }

        public List<int> Convert(int n)
        {
            var res = new List<int>();
            do
            {
                res.Add(n % 2);
                n /= 2;
            } while (n != 0);

            res.Reverse();
            return res;
        }
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindIntegersNaiveTLE(int num)
        {
            var count = 0;
            for (var i = 0; i <= num; i++)
            {
                var pre = -1;
                var n = i;
                while (n > 0)
                {
                    if (pre == 1 && pre == (n & 1))
                    {
                        count--;
                        break;
                    }
                    pre = n & 1;
                    n >>= 1;
                }
                count++;
            }

            return count;
        }
    }
}
