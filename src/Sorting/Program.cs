using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Common.Utilities;
using Sorting.Algorithms;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var fileName = arg;
                var timer = new Stopwatch();
                var inputs = FileReader.ReadLines<int>(fileName);

                //var selectionSort = new SelectionSort();
                //var selectInputs = inputs.ToArray();
                //timer.Start();
                //var selectionSorted = selectionSort.Sort(selectInputs);
                //selectionSort.Print(selectionSorted);
                //timer.Stop();
                //var isSorted = selectionSorted.IsSorted();

                //Console.WriteLine("Selection Sort success: {0} in time {1}", isSorted, timer.Elapsed);

                //var insertionInputs = inputs.ToArray();
                //var insertionSort = new InsertionSort();
                //timer.Reset();
                //timer.Start();
                //var insertionSorted = insertionSort.Sort(insertionInputs);
                //insertionSort.Print(insertionSorted);
                //timer.Stop();
                //isSorted = insertionSorted.IsSorted();

                //Console.WriteLine("Insertion Sort success: {0} in time {1}", isSorted, timer.Elapsed);

                //var mergeInputs = inputs.ToArray();
                //timer.Reset();
                //timer.Start();
                //var mergeSort = new MergeSort(mergeInputs);
                //var mergeSorted = mergeSort.Sort();
                //timer.Stop();
                //var isSorted = mergeSorted.IsSorted();


               // Console.WriteLine("Merge Sort success: {0} in time {1}", isSorted, timer.Elapsed);

                var radix = new RadixSort();
                var radixInputs = inputs.ToArray();

                timer.Start(); 
                var sortedRadix = radix.Sort(radixInputs);
                timer.Stop();
                var isSorted = sortedRadix.IsSorted();

                Console.WriteLine("Merge Sort success: {0} in time {1}", isSorted, timer.Elapsed);

            }
        }
    }
}
