using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FindKPointsToOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            // given a list of Points length N and an origin point (x, y), find k points closest to origin
            var points = new List<Point>();
            points.Add(new Point(1, 5));
            points.Add(new Point(-1, -5));
            points.Add(new Point(-1, -3));
            points.Add(new Point(-1, 2));
            points.Add(new Point(-1, -5));
            points.Add(new Point(-15, 15));
            points.Add(new Point(123, -35));

            var origin = new Point(2, 10);
            CalculateDistances(points, origin);3
            PrintDistance(points);
            Debug.WriteLine("About to sort");
            QuickSelect(points, 3);
            PrintDistance(points);
        }

        public static void CalculateDistances(List<Point> points, Point origin)
        {
            foreach (var point in points)
            {
                point.SetDistanceFromOrigin(origin);
            }
        }

        public static void PrintDistance(List<Point> points)
        {
            points.ForEach(p => Debug.WriteLine(p.Distance)); 
        }


        public static Point QuickSelect(List<Point> list,  int k)
        {
            return QuickSelect(list, 0, list.Count - 1, k);
        }

        public static Point QuickSelect(List<Point> list, int left, int right, int k)
        {
            if (left == right)
            {
                return list[left];
            }
            // TODO: Make this better w/ Median of Three
            var pivodIdx = (right + left)/2;

            pivodIdx = Partition(list, left, right, pivodIdx);
            if (k == pivodIdx)
            {
                return list[k];
            }
            else if (k < pivodIdx)
            {
                return QuickSelect(list, left, pivodIdx - 1, k);
            }
            
            return QuickSelect(list, pivodIdx + 1, right, k);
          
           
        }

        public static int Partition(List<Point> list, int left, int right, int pivot)
        {
            var pivotVal = list[pivot];
            Swap(list, pivot, right);
            var storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (list[i].Distance < pivotVal.Distance)
                {
                    Swap(list, storeIndex, i);
                    storeIndex++;
                }
            }
            Swap(list, right, storeIndex);
            return storeIndex;
        }

        public static void Swap(List<Point> list, int left, int right)
        {
            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
        /*  function partition(list, left, right, pivotIndex)
     pivotValue := list[pivotIndex]
     swap list[pivotIndex] and list[right]  // Move pivot to end
     storeIndex := left
     for i from left to right-1
         if list[i] < pivotValue
             swap list[storeIndex] and list[i]
             increment storeIndex
     swap list[right] and list[storeIndex]  // Move pivot to its final place
     return storeIndex
         * 
         */
    }
}
