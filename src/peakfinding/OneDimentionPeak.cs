using System;
using System.Linq;

namespace PeakFinding
{
    public abstract class OneDimentionPeak
    {
        public abstract int FindPeak(int[] toSearch);

        public virtual bool IsPeak(int[] toSearch, int index)
        {
            var isPeak = false;

            if (toSearch == null || index >= toSearch.Count())
            {
                throw new ArgumentOutOfRangeException();
            
            }
            if (toSearch.Count() == 1)
            {
                isPeak = true;
            }
            else if (index == 0) // Comparing an edge
            {
                isPeak = toSearch[index] >= toSearch[index + 1];
            }
            else if (index == (toSearch.Count() - 1)) // Comparing an edge
            {
                isPeak = toSearch[index] >= toSearch[index - 1]; 
            }
            else
            {
                isPeak = (toSearch[index] >= toSearch[index - 1]) 
                         && toSearch[index] >= toSearch[index + 1]; 
            }

            return isPeak;
        }
    }
}