using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public static class Search
    {
        public static int ArrayLinearSearch<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                {
                    Console.WriteLine("Found value({0}) at index {1}.", value, i);
                    return i;
                }
            }
            Console.WriteLine("failed to find {0} in array", value);
            return -1;
        }

        public static INode<T> ADTLinearSearch<T>(INode<T> ADT, T value)
        {
            var trav = ADT;
            int travCount = 0;
            while (trav.next != null)
            {
                travCount++;
                if (trav.Equals(value))
                {
                    Console.WriteLine("Found value({0}) at the traversed node {1}.", value, travCount);
                    return trav;
                }
            }
            Console.WriteLine("failed to find {0} in ADT", value);
            return null;
        }

        public static int ArrayBinarySearch(int[] array, int value)
        {
            int min = 0;
            int max = array.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (value == array[mid])
                {
                    return ++mid;
                }
                else if (value < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public static int ArrayRecursiveLinearSearch(int[] array, int index, int value)
        {
            if (index >= array.Length)
                return -1;
            if (array[index] == value)
                return index;
            return ArrayRecursiveLinearSearch(array, index + 1, value);
        }

        public static int ArrayRecursiveBinarySearch(int[] array, int high, int low, int value)
        {
            if (high >= low)
            {
                int mid = (high + low) / 2;
                // Console.WriteLine("h: {0}, m: {1}, l: {2}", high, mid, low);

                if (array[mid] == value)
                    return mid;
                if (array[mid] > value)
                    return ArrayRecursiveBinarySearch(array, mid - 1, low, value);
                return ArrayRecursiveBinarySearch(array, high, mid + 1, value);
            }
            return -1;
        }
    }
}
