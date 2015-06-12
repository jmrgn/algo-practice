using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algorithms
{
    /// <summary>
    /// TODO: Implementation
    /// function quicksort(array)
    /// less, equal, greater := three empty arrays
    /// if length(array) > 1  
    ///     pivot := select any element of array
    ///     for each x in array
    ///         if x < pivot then add x to less
    ///         if x = pivot then add x to equal
    ///        if x > pivot then add x to greater
    ///     quicksort(less)
    ///     quicksort(greater)
    ///     array := concatenate(less, equal, greater)
    /// 
    /// </summary>
    public class QuickSort
    {


        /*****************
         * This one works in place
         * 
         * function quicksort(array)
    if length(array) > 1
        pivot := select any element of array
        left := first index of array
        right := last index of array
        while left ≤ right
            while array[left] < pivot
                left := left + 1
            while array[right] > pivot
                right := right - 1
            if left ≤ right
                swap array[left] with array[right]
                left := left + 1
                right := right - 1
        quicksort(array from first index to right)
        quicksort(array from left to last index)
         * 
         * 
         * pivot point - median of first, middle, and last element
     */
    }
}
