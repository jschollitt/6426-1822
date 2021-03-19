using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public static class inClassLib
    {
        public static bool ArrayLinearSearch<T>(T[] array, T value)
        {
            /// loop through the array
            for (var i = 0; i < array.Length; i++)
            {
                /// if the i'th value in the array is what we want
                if (array[i].Equals(value))
                {
                    /// return the index it was found at
                    return true;
                }
            }
            /// return a fail to find
            return false;
        }

        public static int ArrayBinarySearch(int[] array, int value)
        {
            return 0;
        }
    }
}
