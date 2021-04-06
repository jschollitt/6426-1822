using System;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(20, new int[] { 1, 2, 3 });
            Console.WriteLine(stack.ToString());
            stack.push(4);
            stack.push(5);
            stack.push(6);
            Console.WriteLine(stack.ToString());
            stack.pop();
            Console.WriteLine(stack.ToString());
            stack.pop();
            Console.WriteLine(stack.ToString());
            stack.delete();
            Console.WriteLine(stack.ToString());
        }
    }
}
