using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] arr, T val)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
            }
        }
        public static char[,] To2D(this char[][] arr)
        {
            var ret = new char[arr.Length, arr[0].Length];
            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = 0; j < arr[0].Length; j++)
                {
                    ret[i, j] = arr[i][j];
                }
            }

            return ret;
        }
    }
}
