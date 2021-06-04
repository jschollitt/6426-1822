using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week10
{
    /// <summary>
    /// Node contains a name and a list of connected nodes, with paired
    /// weight value (int) to represent distance or time to travel
    /// </summary>
    public class Vertex : IEquatable<Vertex>
    {
        public int ID;
        public int data;
        public List<Vertex> vertices;

        public Vertex(int ID, int data)
        {
            this.ID = ID;
            this.data = data;
            vertices = new List<Vertex>();
        }

        public override string ToString()
        {
            string toReturn = string.Format("[Node] ID: {0}, Data: {1}, Neighbours:  ", ID, data);
            vertices.ForEach(node => toReturn += string.Format("{0}, ", node.ID));
            return toReturn;
        }

        public bool Equals(Vertex node)
        {
            return this.ID == node.ID;
        }
    }

    public class Edge
    {
        public Vertex from;
        public Vertex to;

        public bool bIsWeighted = false;
        public bool bIsDirected = false;

        public int weight = 0;

        public Edge() { }
        public Edge(Vertex from, Vertex to)
        {
            this.from = from;
            this.to = to;
        }
        public Edge(Vertex from, Vertex to, bool isDirected, int weight = 0) : this(from, to)
        {
            bIsDirected = isDirected;
            this.weight = weight;
            bIsWeighted = weight > 0;
        }

        public override string ToString()
        {
            return string.Format("[Edge] From: {0}, To: {1}", from, to);
        }
    }

    public class Subset
    {
        public Vertex parent;
        public int rank;

        public override string ToString()
        {
            return $"Subset with rank {rank}, parent: {parent.data}(ID: { parent.ID})";
        }
    }

    public class Graph
    {
        public List<Vertex> vertices;

        public Graph()
        {
            this.vertices = new List<Vertex>();
        }

        public Vertex AddNode(int ID, int value)
        {
            Vertex node = new Vertex(ID, value);
            vertices.Add(node);
            return node;
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            from.vertices.Add(to);
            to.vertices.Add(from);
        }

        public void RemoveVertex(Vertex toRemove)
        {
            vertices.Remove(toRemove);
            foreach (Vertex node in vertices)
            {
                RemoveEdge(node, toRemove);
            }
        }

        public void RemoveEdge(Vertex from, Vertex to)
        {
            foreach (Vertex vertex in from.vertices)
            {
                if (vertex == to)
                    from.vertices.Remove(vertex);
            }
        }

        public List<Edge> GetEdges()
        {
            List<Edge> edges = new List<Edge>();
            foreach (Vertex from in vertices)
            {
                foreach (Vertex to in from.vertices)
                {
                    Edge edge = new Edge();
                    edge.from = from;
                    edge.to = to;

                    edges.Add(edge);
                }

            }
            return edges;
        }

        //////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////   Traversal  //////////////////
        
        public List<Vertex> DFS()
        {
            List<Vertex> result = new List<Vertex>();
            DFS(vertices[0], result);
            return result;
        }

        private void DFS(Vertex trav, List<Vertex> result)
        {
            result.Add(trav);

            foreach(Vertex neighbour in trav.vertices)
            {
                if (!result.Contains(neighbour))
                {
                    DFS(neighbour, result);
                }
            }
        }

        public List<Vertex> BFS()
        {
            return BFS(vertices[0]);
        }

        private List<Vertex> BFS(Vertex node)
        {
            List<Vertex> result = new List<Vertex>();
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Vertex next = queue.Dequeue();
                result.Add(next);

                foreach(Vertex neighbour in next.vertices)
                {                    
                    if (!result.Contains(neighbour) && !queue.Contains(neighbour))
                    { 
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return result;
        }

        public List<Edge> MSTKruskal()
        {
            List<Edge> edges = GetEdges();
            edges.Sort((a, b) => a.weight.CompareTo(b.weight));
            Queue<Edge> queue = new Queue<Edge>(edges);

            Subset[] subsets = new Subset[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                subsets[i] = new Subset() { parent = vertices[i] };
            }

            List<Edge> result = new List<Edge>();

            while (result.Count < vertices.Count - 1)
            {
                Edge edge = queue.Dequeue();
                Vertex from = GetRoot(subsets, edge.from);
                Vertex to = GetRoot(subsets, edge.to);
                if (from != to)
                {
                    result.Add(edge);
                    Union(subsets, from, to);
                }
            }
            return result;
        }

        private Vertex GetRoot(Subset[] subsets, Vertex vertex)
        {
            
            if (subsets[vertex.ID].parent != vertex)
            {
                subsets[vertex.ID].parent = GetRoot(subsets, subsets[vertex.ID].parent);
            }
            return subsets[vertex.ID].parent;
        }

        private void Union(Subset[] subsets, Vertex a, Vertex b)
        {
            if (subsets[a.ID].rank > subsets[b.ID].rank)
            {
                subsets[b.ID].parent = a;
            }
            else if (subsets[a.ID].rank < subsets[b.ID].rank)
            {
                subsets[a.ID].parent = b;
            }
            else
            {
                subsets[b.ID].parent = a;
                subsets[a.ID].rank++;
            }
        }
    }
}
