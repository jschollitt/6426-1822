using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    static class Sort
    {
        /// <summary>
        /// Helper method. Prints the elements of an array
        /// to the console.
        /// </summary>
        /// <param name="array"></param>
        public static void PrintArray(int[] array)
        {
            Console.Write("[ ");
            foreach (int i in array)
                Console.Write(i + ", ");
            Console.WriteLine("]\n");
        }


        /// <summary>
        /// Helper method. Allows us to handle variable swapping
        /// in arrays the same way for all sorting algorithms.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(T[] array, int a, int b) where T : IComparable
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
        
        /// <summary>
        /// Bubble sort implementation. Highy inefficient.
        /// Iterates through the array and 'bubbles' the highest
        /// value to the end by swapping it with the right-hand neighbour
        /// continuously until it cannot go any further.
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(int[] array)
        {
            /// loop for each element in the array (i is not used)
            for (int i = 0; i < array.Length; i++)
            {
                /// flag for checking if any change has been made
                bool isAnyChange = false;

                /// the 'bubble' loop.
                for (int j = 0; j < array.Length - 1; j++)
                {
                    /// check each index against its neighbour.
                    /// If bigger, swap them.
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        /// update the flag to show a change has been made
                        isAnyChange = true;
                    }
                }
                /// If no changes were made on a pass, sorting is finished early.
                if (!isAnyChange)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Selection Sort implementation.
        /// Iterates through the array, finds the lowest value,
        /// and moves it to the front of the array
        /// </summary>
        /// <param name="array"></param>
        public static void SelectionSort(int[] array)
        {
            /// Loop over array
            for (int i = 0; i < array.Length - 1; i++)
            {
                /// Keep track of the lowest value and index
                int minIndex = i;
                int minValue = array[i];

                /// loop over the unmoved elements.
                /// After "i" loops, the number of sorted elements
                /// is equal to 'i + 1', so we can avoid checking
                /// these sorted elements next time through
                for (int j = i + 1; j < array.Length; j++)
                {
                    /// check current element against known smallest
                    if (array[j] < minValue)
                    {
                        /// current element is the new smallest
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                /// After a pass, move the smallest found element to
                /// the front (elements 0 to i are sorted).
                Swap(array, i, minIndex);
            }
        }

        /// <summary>
        /// Insertion Sort implementation.
        /// Separates the array into sorted and unsorted parts.
        /// Take an unsorted value and loop over the sorted part
        /// until we find where it fits. Repeat until no more
        /// unsorted elements remain.
        /// </summary>
        /// <param name="array"></param>
        public static void InsertionSort(int[] array)
        {
            /// Loop over array (skip the first element, it is the
            /// first element of the sorted part. All elements left
            /// of i are sorted.
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                /// Keep shuffling the unsorted element along the
                /// sorted array (right-to-left) until it is in 
                /// a sorted location
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }

        /// <summary>
        /// Quicksort starter method. Calls the overloaded method
        /// with a specified lower and upper value.
        /// </summary>
        /// <param name="array"></param>
        public static void Quicksort(int[] array)
        {
            Quicksort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Overloaded Quicksort method.
        /// Gets a pivot point in the array and splits the array
        /// into 2 halves. Recursively calls itself with each half.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static int[] Quicksort(int[] array, int lower, int upper)
        {
            /// If lower is smaller than upper, the array has not
            /// been completely sorted. Split it and keep sorting.
            if (lower < upper)
            {
                int p = Partition(array, lower, upper);
                Quicksort(array, lower, p);
                Quicksort(array, p + 1, upper);
            }
            return array;
        }

        /// <summary>
        /// The pivoting and sorting part of the quicksort algorithm.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static int Partition(int[] array, int lower, int upper)
        {
            int i = lower;
            int j = upper;

            /// Choose a location between lower and upper to pivot from.
            /// The value of pivot can be set to any index from lower
            /// to upper (inclusively). 
            /// EG: pivot = array[lower]
            /// EG: pivot = array[upper]
            /// etc
            int pivot = array[(lower + upper) / 2];
            
            /// While the lower and upper indices haven't met
            while (i <= j)
            {
                /// move the lower to the right until it hits the pivot
                while (array[i] < pivot)
                    i++;

                /// move the upper to the left until it hits the pivot
                while (array[j] > pivot)
                    j--;

                /// if i is equal or greater than j, the section is sorted.
                /// Return.
                if (i >= j)
                    return j;

                /// If not done, swap the elements and move the lower and
                /// upper bounds inwards.
                Swap(array, i, j);
                i++;
                j--;
            }
            /// Lower and upper have met. Elements are sorted.
            return j;
        }
    }
}
