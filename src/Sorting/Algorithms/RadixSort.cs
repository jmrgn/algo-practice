using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algorithms
{
    public class RadixSort : ISort<int>
    {

        public int[] Sort(int[] toSort)
        {
            int max = GetMax(toSort);
            int length = max.ToString().Length;

            for (int i = 0; i < length; i++)
            {
                CountingSort(toSort, i);
            }
            return toSort;
        }

       
        private int GetMax(int[] toSort)
        {
            int max = 0;
            // O(N)
            for (int i = 0; i < toSort.Length; i++)
            {
                if (toSort[i] > max)
                {
                    max = toSort[i];
                }
            }
            return max;
        }




        public int[] CountingSort(int[] toSort, int exp)
        {

            int[] output = new int[toSort.Length];
            IList<IList<int>> digits = new List<IList<int>>();
            for (int i = 0; i < 10; i++)
            {
                digits.Add(new List<int>());
            }      
            
            // iterate through the array, increment counts of each occurrence of toSort[i]
            // 0(N)
            for (int i = 0; i < toSort.Length; i++)
            {
                var num = (toSort[i]%Math.Pow(10, exp + 1));
                var denom = Math.Pow(10, exp);
                int digit = (int)(num / denom);

                digits[digit].Add(toSort[i]);
                
            }

            
            int index = 0;
            for (int k = 0; k < digits.Count; k++)
            {
                IList<int> selDigit = digits[k];

                for (int l = 0; l < selDigit.Count; l++)
                {
                    toSort[index++] = selDigit[l];
                }
            }
#if DEBUG
            Print(toSort);
#endif
            return output;
        }

        public void Print(int[] toPrint)
        {
            Console.WriteLine("Array Contents after Radix Sort: ");

            for (int i = 0; i < toPrint.Count(); i++)
            {
                Console.WriteLine(toPrint[i]);
            }

            Console.WriteLine("------------------");
        }

    }
}