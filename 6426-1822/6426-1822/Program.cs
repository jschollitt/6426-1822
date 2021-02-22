using System;

namespace _6426_1822
{
    class Program
    {
        /// <summary>
        /// The starting point of the program. Add code here to
        /// initialise an instance of your class(es).
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            SampleClass sampleClass = new SampleClass();
            sampleClass.sampleGlobalVarB = 5;
            
            Console.WriteLine(sampleClass.ToString());
        }
    }
}
