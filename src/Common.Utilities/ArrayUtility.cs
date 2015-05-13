using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class ArrayUtility
    {
        public static bool IsSorted(this int[] toCheck)
        {
            for (int i = 1; i < toCheck.Length; i++)
            {
                if (toCheck[i - 1] > toCheck[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}