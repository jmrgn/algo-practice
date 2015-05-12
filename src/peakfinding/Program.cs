using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Common.Utilities;

namespace PeakFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];

            var countComparisons = 0;
            var timer = new Timer();
            var inputs = FileReader.ReadLines<int>(fileName);
        }
    }

    public class StraightForward : OneDimentionPeak
    {
        /// <summary>
        /// Returns the index of a peak. Brute force as a baseline. Time Complexity: Theta(n)
        /// </summary>
        /// <returns></returns>
        public override int FindPeak(int[] toSearch)
        {
            for (var i = 0; i < toSearch.Count(); i++)
            {
                if (IsPeak(toSearch, i))
                {
                    return toSearch[i];
                }
            }

            throw new ArgumentException("No peaks were found.");
        }
    }

    public class DivideAndConquer : OneDimentionPeak
    {
        /// <summary>
        /// Returns the index of a peak. Brute force as a baseline. Time Complexity: Theta(n)
        /// </summary>
        /// <returns></returns>
        public override int FindPeak(int[] toSearch)
        {
            
            var size = toSearch.Count();
            return FindPeak(0, size, toSearch);

        }

        public int FindPeak(int low, int high, int[] toSearch)
        {
            // get midpoint
            var mid = (low + high) / 2;

            if (IsPeak(toSearch, mid))
            {
                return mid;
            }
           
            // look left, look right in sequence
            if (toSearch[mid] <  toSearch[mid - 1])
            {
                // go left
                return FindPeak(low, mid - 1, toSearch);
            }
            else if (toSearch[mid] < toSearch[mid + 1])
            {
                // go right
                return FindPeak(mid + 1, high, toSearch);
            }

            // if middle 
            return mid;

        }
    }
}
