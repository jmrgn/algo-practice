using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Visualize a heap as a nearly complete binary tree.
    /// 
    /// | 1  | 2  | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10 |
    /// | 16 | 14 | 10 | 08 | 07 | 09 | 03 | 02 | 04 | 01 | 
    ///                                 16(1)
    ///                     14(2)                 10(3)
    ///            08(4)            07(5)   09(6)     03(7)   
    ///         02(8)    04(9)    01(10)     
    /// Root of the tree: First element, (i = 1)
    /// Parent(i) = i/2
    /// left child: 2i
    /// right child: 2i + 1
    /// Max Heap: Key of a node >= keys of its children
    /// This library uses CompareTo in order to be generic. 
    /// Less than Zero: This instance precedes obj in the sort order i.e. foo.CompareTo(bar), foo is less than bar
    /// Zero: This instance occurs in the same position in the sort order as obj. i.e. foo.CompareTo(bar), foo is equal to bar 
    /// Greater than zero: This instance follows obj in the sort order.  i.e. foo.CompareTo(bar), foo is greater than bar
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> where T : IComparable  
    {
        private T[] elements = new T[]{};
        private int count = 0;
        public MaxHeap(T[] heap)
        {
            elements = heap;
            count = heap.Length;

            BuildMaxHeap();
        }

        public T[] Elements { get { return elements; } }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            T tmp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = tmp;
        }

        /// <summary>
        /// For i = n/2 down to 1
        ///     Do MaxHeapify(i)
        /// Special case: If there is only one valid
        /// Why is this? A[n/2...n are all leaves, and by definition are all max heaps
        /// </summary>
        public void BuildMaxHeap()
        {
            for (int i = Count / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
            
        }

        public void MaxHeapify(int idx)
        {
            int largest = idx;

            int lChildIdx = 2*(idx) + 1;
            int rChildIdx = 2*(idx) + 1 + 1;

            // Determine the max heap by comparing parent to children
            // Make sure the child indexes are valid, and then compare the values
            if (lChildIdx < Count && (elements[lChildIdx].CompareTo(elements[idx]) > 0))
            {
                // left child is larger than parent. 
                largest = lChildIdx;
            }
            if (rChildIdx < Count && (elements[rChildIdx].CompareTo(elements[largest]) > 0))
            {
                // righ child is larger than the largest so far
                largest = rChildIdx;
            }

            // Swap, and keep
            if (idx != largest)
            {
                SwapElements(idx, largest);
                MaxHeapify(idx);
            }

        }

        public T PeekMax()
        {
            if (elements.Length > 0)
            {
                T item = elements[0];
                return item;
            }
            throw new ArgumentOutOfRangeException();  
        }

        public T ExtractMax()
        {
            T max = elements[0];
            
            SwapElements(0, count - 1);
            count--;
            BuildMaxHeap();

            return max;
        }

        public int Count
        {
            get { return count; }
        }

    }
}
