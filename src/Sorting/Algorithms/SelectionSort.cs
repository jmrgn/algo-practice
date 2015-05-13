using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algorithms
{
    /// <summary>
    /// Time Complexity: Theta(n^2)
    /// Space Complexity: O(1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SelectionSort<T>
    {
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
        
        public virtual bool ShouldSwap(Func<bool> comparison) // Completely useless. Just playing around with first-class functions
        {
            return comparison();
        }
        
    }

    public class SelectionSort : SelectionSort<int>, ISort<int>
    {
        public int[] Sort(int[] toSort)
        {
            var count = toSort.Count();
            int tmp, min_key;

            for (int i = 0; i < count - 1; i++)
            {
                min_key = i;

                // find the next min
                for (int j = i + 1; j < count; j++)
                {
                    //TODO: play around with modified closures more
                    if (ShouldSwap(() => Compare(toSort[min_key], toSort[j])))
                    {
                        min_key = j;
                    }
                }

                // Do the swap
                toSort = this.Swap(min_key, i, toSort);

#if DEBUG
                // Avoid IO if we're perf testing in release mode
                Print(toSort, i);
#endif
            }

            return toSort;
        }

        /// <summary>
        /// TODO: Move to base class, extension method, or utility method
        /// </summary>
        /// <param name="toPrint"></param>
        /// <param name="iteration"></param>
        private void Print(int[] toPrint, int iteration)
        {
            Console.WriteLine("Array after {0} iteration(s)", iteration);
            Print(toPrint);
        }

        public void Print(int[] toPrint)
        {
            Console.WriteLine("Array Contents after Selection Sort: ");

            for (int i = 0; i < toPrint.Count(); i++)
            {
                Console.WriteLine(toPrint[i]);
            }

            Console.WriteLine("------------------");
        }

        private bool Compare(int oldMin, int toCompare)
        {
            return toCompare < oldMin;
        }
    }
}
