using System;
using System.Linq;
using System.Collections.Generic;

namespace Week7
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTree = new Tree();

            Random random = new Random();
            
            List<int> myList = new List<int>(Enumerable.Range(1, 20).OrderBy(num => random.Next()));
            foreach (int i in myList)
                myTree.Add(i);

            Console.WriteLine(myTree.ToString());
            myTree.Add(30);
            Console.WriteLine(myTree.ToString());
            myTree.Remove(15);
            Console.WriteLine(myTree.ToString());

            List<TreeNode> preList = myTree.Traverse();

            Console.ReadLine();
        }
    }
}
