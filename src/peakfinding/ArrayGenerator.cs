using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFinding
{
    public static class ArrayGenerator
    {

        public static int[] GenerateOneDimentionalArray(int minSize = 20, int maxSize = 50, int maxVal = 20000)
        {
            var seed = DateTime.Today.Millisecond;
            var rand = new Random(seed);

            // max value 
            var size = rand.Next(minSize, maxSize);

            var toSearch = new int[size];
            for (var i = 0; i < size; i++)
            {
                toSearch[i] = rand.Next(maxVal);
            }
            return toSearch;
        }

        public static int[,] GenerateTwoDimentionalArray(int minSize = 20, int maxSize = 50, int maxVal = 20000)
        {
            var seed = DateTime.Today.Millisecond;
            var rand = new Random(seed);

            
            var nHeight = rand.Next(minSize, maxSize);
            var mWidth = rand.Next(minSize, maxSize);
            
            // Two-D array of nHeight rows, mWidth columns
            var toSearch = new int[nHeight, mWidth];
            
            for (var i = 0; i < nHeight; i++)
            {
                for (var j = 0; j < mWidth; j++)
                {
                    toSearch[i, j] = rand.Next(maxVal);
                }
            }
            return toSearch;
        }
    }
}
