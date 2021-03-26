using System;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nBubble Sort:");
            Test.RunTest(Sort.BubbleSort);
            Console.WriteLine("\n\nInsertion Sort:");
            Test.RunTest(Sort.InsertionSort);
            Console.WriteLine("\n\nSelection Sort:");
            Test.RunTest(Sort.SelectionSort);
            Console.WriteLine("\n\nQuicksort:");
            Test.RunTest(Sort.Quicksort);
        }
    }

}
