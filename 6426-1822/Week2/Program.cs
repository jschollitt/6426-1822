using System;
using System.Linq;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FizzBuzz();

            LinkedList myLinkedList = new LinkedList();
            
            /// Enumerable.Range is available in System.Linq namespace.
            /// Remember to include it at the top of your file.
            foreach (int i in Enumerable.Range(1, 10))
            {
                myLinkedList.AddNode(i);
            }
        }

        /// <summary>
        /// FizzBuzz method.
        /// Uses the static keyword to allow the method to be called
        /// without needing an instance of the class
        /// </summary>
        public static void FizzBuzz()
        {
            /// Ask for a number from user
            Console.WriteLine("Enter a number:");

            /// Take the input, save to a local string var
            string input = Console.ReadLine();

            /// Convert string to int
            int inputNum = Convert.ToInt32(input);

            /// For each int from 1 to given number
            for (int i = 1; i < inputNum; i++)
            {
                /// If i is multiple of 3 and 5
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");

                /// If not multiple of both, is multiple of just 3
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");

                /// If not multiple of both, is multiple of just 5
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");

                /// If none of the above, print the number
                else
                    Console.WriteLine(i);
            }
        }
    }
}
