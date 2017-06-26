using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSites.Problems.Pramp
{
    public class DecryptMessage
    {
        public string Encrypt(string word)
        {
            //'a' .. 'z' 97..122
            // convert to ascii
            // add 1 to first
            // keep add with previous
            // subtract 26 till ascii
            return word;
        }


        public string Decrypt(string word)
        {
            var sb = new StringBuilder();
            var pre = 1;
            for(var i = 0; i < word.Length; ++i)
            {
                var c = (int)word[i];
                c = c - pre; // be careful c could be negative. negative char might be a unicode. so we should use int for c before convert back to char.
                while (c < 'a')
                {
                    c += 26;
                }

                sb.Append((char)c);
                pre += c;
            }
            return sb.ToString();
        }

        public string DecryptWrong(string word)
        {
            // add back 26
            // c[n] = c[n] - c[n-1]
            // first calc -1
            // 

            var chars = word.ToCharArray();
            var ascii = new int[word.Length];
            for (var i = 0; i < word.Length; i++)
            {
                ascii[i] = (int)chars[i];
            }

            for (var i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    ascii[i] = ascii[i] - 1;
                }
                else
                {
                    ascii[i] -= ascii[i - 1];

                    while (!(ascii[i] >= 'a' && ascii[i] <= 'z'))
                    {
                        ascii[i] += 26;
                    }
                }
            }
            for (var i = 0; i < word.Length; i++)
            {
                chars[i] = (char)ascii[i];
            }

            var s = new string(chars);
            return s;
        }
    }
}
