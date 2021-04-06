using System;
using System.Collections.Generic;
using System.Text;

namespace Week5
{
    /// <summary>
    /// Node class using generics and inheritence requirements.
    /// The data type of value is the datatype passed to the
    /// constructor. 
    /// EG: Node<int> myNode = new Node<int>(1);
    /// The 'where T : IComparable' makes sure that the T datatype
    /// can only be a type that inherits from the IComparable interface.
    /// This means that all Nodes can use the .CompareTo() method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> where T : IComparable
    {
        private T _value;
        public T value
        {
            get 
            { 
                return _value; 
            }
            set 
            { 
                if (!value.Equals(null)) 
                    this._value = value; 
            }
        }
        public Node<T> next;

        public Node(T value)
        {
            this.value = value;
        }
    }
    public class Stack
    {
        int max = 10; /// arbitrary default max size
        int count = 0;
        Node<int> head = null;

        public Stack()
        {
        }

        public Stack(int sizeLimit)
        {
            this.max = sizeLimit;
        }

        /// overloaded constructor that uses ctor chaining to reduce
        /// replicating code across constructors.
        public Stack(int sizeLimit, int[] startingValues) : this(sizeLimit)
        {
            foreach(int val in startingValues)
            {
                this.push(val);
            }
        }

        /// Add a new node to the top of the stack
        public void push(int value)
        {
            ++this.count;
            Node<int> newNode = new Node<int>(value);
            newNode.next = this.head;
            this.head = newNode;
        }

        /// remove the top node from the stack and return
        /// the value
        public int pop()
        {
            if (this.head == null) return -1;

            --this.count;
            var v = this.head.value;
            this.head = this.head.next;
            return v;
        }

        /// Remove the entire stack by separating the link
        /// and let gc clean it up later
        public void delete()
        {
            /// It is tempting to do this:
            ///     while (this.count > 0)
            ///         this.pop();
            ///         
            /// But it achieves the same result as:
            this.head = null;
            this.count = 0;
        }

        /// <summary>
        /// Method for traversing and printing the contents
        /// of the stack.
        /// Uses a stringbuilder instead of appending strings
        /// manually to save on memory.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.count < 1) return "Stack is empty";
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            Node<int> trav = this.head;
            while (trav.next != null)
            {
                sb.Append(trav.value.ToString() + ", ");
                trav = trav.next;
            }
            sb.Append(trav.value.ToString() + " ]");

            return sb.ToString();
        }
    }
}
