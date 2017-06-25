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

        public static T[][] To2D<T>(this T[,] arr)
        {
            var ret = new T[arr.GetLength(0)][];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                ret[i] = new T[arr.GetLength(1)];
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    ret[i][j] = arr[i,j];
                }
            }

            return ret;
        }

        public static T[,] To2D<T>(this T[][] arr)
        {
            var ret = new T[arr.Length, arr[0].Length];
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
