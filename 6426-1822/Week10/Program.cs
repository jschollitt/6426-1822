using System;
using System.Collections.Generic;

namespace Week10
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //Edge e2 = new Edge(n1, n3);
            //Edge e3 = new Edge(n2, n4);
            //Edge e4 = new Edge(n2, n5);
            //Edge e5 = new Edge(n3, n5);
            //Edge e6 = new Edge(n5, n6);


            Vertex n1 = graph.AddNode(0, 10);
            Vertex n2 = graph.AddNode(1, 4);
            Vertex n3 = graph.AddNode(2, 7);
            Vertex n4 = graph.AddNode(3, 9);
            Vertex n5 = graph.AddNode(4, 8);
            Vertex n6 = graph.AddNode(5, 3);

            graph.AddEdge(n1, n2);
            graph.AddEdge(n1, n3);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n3, n5);
            graph.AddEdge(n5, n6);
            Print(graph.DFS());
            Console.WriteLine("\n\n\n");
            Print(graph.BFS());
            Console.WriteLine("\n\n\n");
            Print(graph.MSTKruskal());

        }

        public static void Print<T>(List<T> nodes)
        {
            nodes.ForEach(n => Console.WriteLine(n));
        }
    }
}
