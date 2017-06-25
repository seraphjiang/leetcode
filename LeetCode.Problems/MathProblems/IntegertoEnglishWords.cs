using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LeetCode.Problems.MathProblems
{
    public class IntegertoEnglishWords
    {
        string[] nums = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] huns = new string[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] bits = new string[] { "", "Thousand", "Million", "Billion" };
        public string NumberToWords(int num)
        {
            {
                if (num == 0) return "";
                if (num < 20) return nums[num];

                if (num >= 1000000000)
                {
                    var left = num / 1000000000;
                    var right = num % 1000000000;
                    return NumberToWords(left) + " Billion" + (right == 0 ? "" : (" " + NumberToWords(right)));
                }
                else if (num >= 1000000)
                {
                    var left = num / 1000000;
                    var right = num % 1000000;
                    return NumberToWords(left) + " Million" + (right == 0 ? "" : (" " + NumberToWords(right)));
                }
                else if (num >= 1000)
                {
                    var left = num / 1000;
                    var right = num % 1000;
                    return NumberToWords(left) + " Thousand" + (right == 0 ? "" : (" " + NumberToWords(right)));
                }
                else if (num >= 100)
                {
                    var left = num / 100;
                    var right = num % 100;
                    return NumberToWords(left) + " Hundred" + (right == 0 ? "" : (" " + NumberToWords(right)));
                }
                else
                {//>20
                    var left = num / 10;
                    var right = num % 10;
                    return huns[left] + (right == 0 ? "" : (" " + NumberToWords(right)));
                }
            }
        }
    }
}
