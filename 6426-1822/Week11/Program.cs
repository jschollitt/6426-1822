using System;
using System.Collections;

namespace Week11
{
    class Program
    {
        static void Main(string[] args)
        {
            FloodFill fill = new FloodFill();
            //fill.Run();

            Hashtable phonebook = new Hashtable();

            phonebook.Add("John Smith", "0211111111");
            phonebook.Add("Jane Smith", "0212222222");
            phonebook.Add("Andy Wood", "0223333333");
            phonebook.Add("Tommy Butler", "0224444444");

            Console.WriteLine(phonebook["John Smith"]);

            Hashtable People = new Hashtable();
            People.Add("John Smith", new Person { name = "John Smith", age = 34 });
            People.Add("Jane Smith", new Person { name = "Jane Smith", age = 35 });
            People.Add("Andy Wood", new Person { name = "Andy Wood", age = 19 });

            Random r = new Random();

            Stack stack = new Stack();
            stack.Add(r.Next(1, 20));
            

            int[] myArray = new int[r.Next(10, 20)];
            for(int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = r.Next(1, 1000);
                Console.WriteLine(myArray[i]);
            }

           
        }
    }

    public class Stack
    {
        public Stack() { }
        public void Add(int i) { }

    }

    public class Person
    {
        public string name;
        public int age;

    }
}
