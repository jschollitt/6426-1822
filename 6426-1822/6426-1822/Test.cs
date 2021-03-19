using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TimeTest_Sample
{
    public class Test
    {
        /// <summary>
        /// Static method that takes a reference to a method as a parameter.
        /// The passed method must take an integer parameter that is used
        /// to determine the number of times an action is performed.
        /// </summary>
        /// <param name="runFunc"></param>
        public static void RunTest(Action<int> runFunc)
        {
            /// Create 2 arrays, 1 for test sizes, 1 for holding the elapsed times
            int[] inputLengths = { 10, 100, 1000, 10000, 100000, 200000 };
            TimeSpan[] elapsedTimes = new TimeSpan[6];

            Console.WriteLine("Beginning tests...");

            /// start the timer
            var watch = Stopwatch.StartNew();

            /// loop over the test lengths
            for (int i = 0; i < inputLengths.Length; i++)
            {
                /// restart the timer
                watch.Restart();
                Console.Write("Running function with {0} length...", inputLengths[i]);

                /// call the passed method with the test length as parameter
                runFunc(inputLengths[i]);

                /// save the time taken to perform
                elapsedTimes[i] = watch.Elapsed;
                Console.WriteLine("Function completed execution.");
            }

            /// print out the results for the tests
            Console.WriteLine("\nFinished tests... Results below:\n");
            for (int i = 0; i < elapsedTimes.Length; i++)
            {
                Console.WriteLine("iterations: {0:0000000}\t Elapsed Time: {1}", inputLengths[i], elapsedTimes[i]);
            }
        }
    }
}
