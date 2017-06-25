using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LeetCode.Problems.MathProblems
{
    public class IntegertoEnglishWords
    {
        string[] LESS_THAN_20 = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] TENS = new string[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        string[] THOUSANDS = new string[] { "", "Thousand", "Million", "Billion" };

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            int i = 0;
            var words = "";

            while (num > 0)
            {
                if (num % 1000 != 0)
                    words = helper(num % 1000) + THOUSANDS[i] + " " + words;
                num /= 1000;
                i++;
            }

            return words.Trim();
        }

        private string helper(int num)
        {
            if (num == 0)
                return "";
            else if (num < 20)
                return LESS_THAN_20[num] + " ";
            else if (num < 100)
                return TENS[num / 10] + " " + helper(num % 10);
            else
                return LESS_THAN_20[num / 100] + " Hundred " + helper(num % 100);
        }

        public string NumberToWords1(int num)
        {
            {
                if (num < 20) return LESS_THAN_20[num];

                if (num >= 1000000000)
                {
                    var left = num / 1000000000;
                    var right = num % 1000000000;
                    return NumberToWords1(left) + " Billion" + (right == 0 ? "" : (" " + NumberToWords1(right)));
                }
                else if (num >= 1000000)
                {
                    var left = num / 1000000;
                    var right = num % 1000000;
                    return NumberToWords1(left) + " Million" + (right == 0 ? "" : (" " + NumberToWords1(right)));
                }
                else if (num >= 1000)
                {
                    var left = num / 1000;
                    var right = num % 1000;
                    return NumberToWords1(left) + " Thousand" + (right == 0 ? "" : (" " + NumberToWords1(right)));
                }
                else if (num >= 100)
                {
                    var left = num / 100;
                    var right = num % 100;
                    return NumberToWords1(left) + " Hundred" + (right == 0 ? "" : (" " + NumberToWords1(right)));
                }
                else
                {//>20
                    var left = num / 10;
                    var right = num % 10;
                    return TENS[left] + (right == 0 ? "" : (" " + NumberToWords1(right)));
                }
            }
        }


        /// <summary>
        /// Input:
        /// 1000000
        /// Output:
        /// "One Million Thousand"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string NumberToWordsWrong(int num)
        {
            if (num < 20) return LESS_THAN_20[num];
            var sb = new StringBuilder();
            var pow = 1;
            while (num > 0)
            {
                var left = num / 1000;
                var right = num % 1000;

                sb.Insert(0, Help(right));
                if (left > 0)
                {
                    if (right > 0) sb.Insert(0, " ");
                    sb.Insert(0, THOUSANDS[pow++]);
                }

                num = left;
            }

            return sb.ToString();
        }

        public string Help(int num)
        {
            if (num == 0) return "";
            if (num < 20) return LESS_THAN_20[num];
            var sb = new StringBuilder();
            if (num >= 100)
            {
                var left = num / 100;
                var right = num % 100;
                sb.Append(LESS_THAN_20[left] + (right != 0 ? " Hundred " + Help(right) : " Hundred"));
            }
            else if (num >= 20)
            {
                sb.Append(TENS[num / 10] + (num % 10 != 0 ? " " + LESS_THAN_20[num % 10] : ""));
            }
            else
            {
                sb.Append(LESS_THAN_20[num]);
            }

            return sb.ToString();
        }
    }
}
