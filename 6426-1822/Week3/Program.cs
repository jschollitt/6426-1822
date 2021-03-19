using System;
using System.Linq;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myNewArray = Enumerable.Range(0, 100).ToArray();
            
            Console.WriteLine("Hello World!");

            Random r = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(0, 100);
                Console.Write("{0}, ", array[i]);
            }

            int[] sortedArray = Enumerable.Range(0, 100).ToArray();

            for (int i = 0; i < array.Length; i++)
                if (array[i] == 17) 
                    Console.WriteLine("Found at index {0}", i);

            Console.WriteLine("Recursive looking for {0}: {1}", 17, Search.ArrayRecursiveLinearSearch(sortedArray, 0, 17));
            Console.WriteLine("Recursive binary looking for {0}: {1}", 17, Search.ArrayRecursiveBinarySearch(sortedArray, sortedArray.Length - 1, 0, 17));

        }
    }
}