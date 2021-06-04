using System;
using System.Linq;

namespace Week9
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap myHeap = new Heap();
            foreach (int i in Enumerable.Range(1, 10))
            {
                myHeap.insert(i);
                Console.WriteLine(myHeap.ToString());
            }
            foreach (int i in Enumerable.Range(1, 10))
            {
                Console.WriteLine("deleted: {0}", myHeap.delete());
                Console.WriteLine(myHeap.ToString());
            }
        }
    }
}
