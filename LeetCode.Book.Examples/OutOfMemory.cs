using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Book.Examples
{
    public class OutOfMemory
    {
        public static void BurnMemory()
        {
            for(var i = 1; i <= 1024; i++)
            {
                long size = 1 << i;
                long t = 4 * size / (1 << 30);
                try
                {
                    // 1 int32 takes 32 bit(4 byte) memmory, 
                    var arr = new int[size];

                    Console.WriteLine("Test pass initialize a array with size = 2^" + i.ToString());
                }
                catch(OutOfMemoryException err)
                {
                    Console.WriteLine("Reach memory limitation when initialize a array with size = 2^{0} int32 = 4 x {1}B= {2}TB",i, size, t );
                    break;
                }
            }
        }
    }
}
