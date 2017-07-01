using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Book.Examples
{
    public class MatrixRotation
    {
        public static T[,] HorizontalFlip<T>(T[,] source)
        {
            //scan col by col, reverse each column
            for (var i = 0; i < source.GetLength(1); i++)
            {
                int t = 0, b = source.GetLength(0) - 1;
                while (t < b)
                {
                    var x = source[t, i];
                    source[t, i] = source[b, i];
                    source[b, i] = x;
                    t++;b--; // don't forget to change loop variable
                }
            }

            return source;
        }

        public static T[,] VerticalFlip<T>(T[,] source)
        {
            //scan row by row, reverse each row
            for (var i = 0; i < source.GetLength(0); i++)
            {
                int l = 0, r = source.GetLength(1) - 1;
                while (l < r)
                {
                    var t = source[i, l];
                    source[i, l] = source[i, r];
                    source[i, r] = t;
                    l++;r--;
                }
            }
            return source;
        }

        public static T[,] SquareDiagnoalFlip<T>(T[,] source)
        {
            // main diagonal = clockwise rotate + vertical flip
            // top left to bottom right

            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            if (rows != cols) throw new InvalidOperationException("Cannot use this algorithm to flip rectangle, must be square!");

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    var x = source[i, j];
                    source[i, j] = source[j, i];
                    source[j, i] = x;
                }
            }

            return source;
        }

        ///
        public static T[,] DiagnoalFlip<T>(T[,] source)
        {
            // main diagonal 
            // top left to bottom right
            var res = new T[source.GetLength(1), source.GetLength(0)];

            // scan left side main diagnoal, swap with right side
            for (var i = 0; i < source.GetLength(0); i++)
            {
                for (var j = 0; j < source.GetLength(1); j++)
                {
                    res[j, i] = source[i, j];
                }
            }

            return res;
        }

        public static T[,] AntiDiagnoalFlip<T>(T[,] source)
        {
            // minor diagnoal or antidiagnoal,for a square it equivalent to clockwise rotate + horizontal flip
            // bottom left to top right
            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            var res = new T[cols, rows];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    res[cols - j, rows - i] = source[i, j];
                }
            }

            return source;
        }
        public static T[,] ClockwiseRotate90Degree<T>(T[,] source)
        {
            // horizontal flip + diagnoal flip
            // or vertical flip + anti-diagnoal flip
            var res = HorizontalFlip(source);
            res = DiagnoalFlip(res);
            return res;
        }
        public static T[,] CounterClockwiseRotate90Degree<T>(T[,] source)
        {
            // vertical flip + diagnoal flip

            var res = VerticalFlip(source);
            res = DiagnoalFlip(source);
            return res;
        }
    }
}
