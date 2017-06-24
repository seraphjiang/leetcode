using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.MathProblems
{
    public class NumberofDigitOne
    {
        /// <summary>
        /// https://discuss.leetcode.com/topic/27565/java-python-one-pass-solution-easy-to-understand
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountDigitOne(int n)
        {
            //The idea is to calculate occurrence of 1 on every digit. There are 3 scenarios, for example
            // if n = xyzdabc
            //and we are considering the occurrence of one on thousand, it should be:
            //(1) xyz * 1000                     if d == 0
            //(2) xyz * 1000 + abc + 1           if d == 1
            //(3) xyz * 1000 + 1000              if d > 1
            
            if (n <= 0) return 0;
            int q = n, x = 1, ans = 0;
            do
            {
                int digit = q % 10;
                q /= 10;
                ans += q * x;
                if (digit == 1) ans += n % x + 1;
                if (digit > 1) ans += x;
                x *= 10;
            } while (q > 0);
            return ans;
        }
        public int CountDigitOne2(int n)
        {
            long ones = 0;
            for (long m = 1; m <= n; m *= 10)
                ones += (n / m + 8) / 10 * m + (n / m % 10 == 1 ? n % m + 1 : 0);
            return (int)ones;
        }
        public int CountDigitOne1(int n)
        {
            int ones = 0, m = 1, r = 1;
            while (n > 0)
            {
                ones += (n + 8) / 10 * m + (n % 10 == 1 ? r : 0);
                r += n % 10 * m;  //
                m *= 10;
                n /= 10;
            }
            return ones;
        }
    }
}
