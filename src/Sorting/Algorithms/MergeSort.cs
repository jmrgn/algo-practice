using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algorithms
{
    /// <summary>
    /// Time Complexity: O(n log(n)) 
    /// Space Complexity: O(n)
    /// </summary>
    public class MergeSort
    {
        private int[] sortArray;
        public MergeSort(int[] toSort)
        {
            this.sortArray = toSort;
;
        }

        /// <summary>
        /// TODO: refactor toSort into private member, remove from interface
        /// </summary>
        /// <returns></returns>
        public int[] Sort()
        {
            if (sortArray.Length <= 1)
            {
                return sortArray;
            }
            return Sort(0, sortArray.Length - 1);
        }

        /// <summary>
        /// Recursively sort the array in divide & conquer fashion
        /// </summary>
        /// <param name="lowIdx"></param>
        /// <param name="highIdx"></param>
        /// <param name="sortArray"></param>
        /// <returns></returns>
        protected int[] Sort(int lowIdx, int highIdx)
        {
            if (highIdx > lowIdx)
            {
                var midPoint = (highIdx + lowIdx) / 2;
                // 1. Sort the left half of the array
                Sort(lowIdx, midPoint);

                // 2. Sort the right half of the array
                Sort(midPoint + 1, highIdx);
                
                // 3. Merge them
                sortArray = Merge(lowIdx, midPoint, highIdx);
            }
#if DEBUG
            //Print(sortArray);
#endif
            return sortArray;
        }

        public void Print(int[] toPrint)
        {
            Console.WriteLine("Array Contents after Merge Sort: ");

            for (int i = 0; i < toPrint.Count(); i++)
            {
                Console.WriteLine(toPrint[i]);
            }

            Console.WriteLine("------------------");
        }

        protected int[] Merge(int lowerIdx, int midIdx, int highIdx)
        {
            // Create a temp array of the size of the sum of the two arrays to be merged
            var temp = new int[highIdx - lowerIdx + 1];

            int i = lowerIdx; // begin point of left half
            int j = midIdx + 1; // begin point of right half
            int k = 0; // temp array placeholder

            // traverse each array and store smallest in temp
            while (i <= midIdx && j <= highIdx)
            {
                // if smallest in lower half, store lower and advance i by 1
                if (sortArray[i] < sortArray[j])
                {
                    temp[k] = sortArray[i];
                    i++;
                }
                else // smallest in upper half, store lower and advance i by 1
                {
                    temp[k] = sortArray[j];
                    j++;
                }

                k++;
                
            }

            // Ensure remaining elements are added to temp array
            // if i isn't ad the midpoint, there are more elements
            for (; i <= midIdx; i++, k++)
            {
                temp[k] = sortArray[i];
            }

            //if j isn't ad the midpoint, there are more elements
            for (; j <= highIdx; j++, k++)
            {
                temp[k] = sortArray[j];
            }

            // Stash temp array back in original
            i = lowerIdx;
            k = 0;
            for(; k < temp.Length && i <= highIdx; i++, k++)
            {
                sortArray[i] = temp[k];
            }

            return sortArray;
        }
    }
}
