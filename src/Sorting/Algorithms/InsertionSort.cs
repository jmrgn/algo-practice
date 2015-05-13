using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algorithms
{
    /// <summary>
    /// Time Complexity: O(n^2) worst case), O(n) best case
    /// Space Complexity: O(1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class InsertionSort<T>
    {
        // TODO: Lots of generic swaps going on. Get this converted to a utility or extension method
        public virtual T[] Swap(int sourceIdx, int destinationIdx, T[] toSwapFrom)
        {
            if (sourceIdx < 0 || destinationIdx < 0 ||
                sourceIdx >= toSwapFrom.Count() || destinationIdx >= toSwapFrom.Count())
            {
                throw new ArgumentOutOfRangeException();
            }

            var temp = toSwapFrom[destinationIdx];
            toSwapFrom[destinationIdx] = toSwapFrom[sourceIdx];
            toSwapFrom[sourceIdx] = temp;

            return toSwapFrom;
        }

    }

    public class InsertionSort : InsertionSort<int>, ISort<int>
    {
        public int[] Sort(int[] toSort)
        {
            if (toSort.Count() == 0)
            {
                return toSort;
            }

            for(var i = 0; i < toSort.Count(); i++)
            {
                for(var j=i; j>0 && toSort[j] < toSort[j-1]; j--)
                {
                    toSort = Swap(j, j - 1, toSort);
                   
#if DEBUG
                    // Avoid IO if we're perf testing in release mode
                    Print(toSort, i);
#endif
                }
            }

            return toSort;
        }

        private void Print(int[] toPrint, int iteration)
        {
            Console.WriteLine("Array after {0} iteration(s)", iteration);
            Print(toPrint);
        }

        public void Print(int[] toPrint)
        {
            Console.WriteLine("Array Contents after Insertion Sort: ");

            for (int i = 0; i < toPrint.Count(); i++)
            {
                Console.WriteLine(toPrint[i]);
            }

            Console.WriteLine("------------------");
        }
    }
}
