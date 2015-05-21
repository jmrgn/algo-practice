using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class HeapTests
    {
        public MaxHeap<int> heap;
            
        [TestCase(10, 9, 8, 10)]
        [TestCase(11, 10, 9, 8, 10)]
        public void ShouldHeapifyNearlyCompleteList(params int[] toHeapify)
        {
            heap = new MaxHeap<int>(toHeapify);
            heap.BuildMaxHeap();
            Print(heap.Elements);
            
        }

        [TestCase(0, 10)]
        [TestCase(0, 10, 11)]
        [TestCase(0, 11, 10)]
        [TestCase(0, 11, 11)]
        [TestCase(0, 10, 9, 8)]
        [TestCase(2, 10, 9, 8)]
        [TestCase(0, 0, 8, 9)]
        [TestCase(0, 10, 19, 7)]
        [TestCase(5, 19, 15, 7, 14, 13, 10 )]
        public void ShouldSwapCorrectly(int beginIdx, params int[] toHeapify)
        {
            heap = new MaxHeap<int>(toHeapify);
            heap.MaxHeapify(beginIdx);
            var afterSwap = heap.Elements;
            Print(afterSwap);
        }

        [TestCase(14, 08, 07, 16, 03, 10, 02, 04, 01, 09)]
        public void ShouldBuildAMaxHeap(params int[] toHeapify)
        {
            heap = new MaxHeap<int>(toHeapify);
            heap.BuildMaxHeap();
            Print(heap.Elements);
        }

        [TestCase(14, 08, 07, 16, 03, 10, 02, 04, 01, 09)]
        public void ShouldBeAbleToSort(params int[] toHeapify)
        {
            heap = new MaxHeap<int>(toHeapify);
            heap.BuildMaxHeap();
            Print(heap.Elements);
            var totalCount = heap.Count;
            Debug.WriteLine("PRINTING Sorted ARRAY:");
            while (heap.Count > 0)
            {
                var extractMax = heap.ExtractMax();
                Debug.WriteLine(extractMax);
            }
            Debug.WriteLine("FINISHED PRINTING");
            
        }

        public void Print(int[] elements)
        {
            Debug.WriteLine("PRINTING ARRAY:");
            foreach (var element in elements)
            {
                Debug.WriteLine(element);
            }
            Debug.WriteLine("FINISHED PRINTING");
        }
    }
}
