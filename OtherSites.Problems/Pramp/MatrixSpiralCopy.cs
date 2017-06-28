using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherSites.Problems.Pramp
{
    public class MatrixSpiralCopy
    {
        //function spiralCopy(inputMatrix):
        //    numRows = inputMatrix.length
        //    numCols = inputMatrix[0].length

        //    topRow = 0
        //    btmRow = numRows - 1
        //    leftCol = 0
        //    rightCol = numCols - 1
        //    result = []

        //    while (topRow <= btmRow AND leftCol <= rightCol):
        //        # copy the next top row
        //        for i from leftCol to rightCol:
        //            result.push(inputMatrix[topRow][i])
        //        topRow++

        //        # copy the next right hand side column
        //        for i from topRow to btmRow:
        //            result.push(inputMatrix[i][rightCol])
        //        rightCol--

        //        # copy the next bottom row
        //        if (topRow <= btmRow):
        //            for i from rightCol to leftCol:
        //                result.push(inputMatri[btmRow][i])
        //            btmRow--

        //        # copy the next left hand side column
        //        if (leftCol <= rightCol):
        //            for i from btmRow to topRow:
        //                result.push(inputMatrix[i][leftCol])
        //            leftCol++

        //    return result
    }
}
