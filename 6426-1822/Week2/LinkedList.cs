using System;
using System.Collections.Generic;
using System.Text;

namespace Week2
{
    /// <summary>
    /// Node class. Responsible for holding a value and
    /// a reference to another node. That's it.
    /// </summary>
    public class LLNode
    {
        public int value;
        public LLNode next;

        public LLNode(int value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Data type class. Handles the creation, manipulation,
    /// modification and removal of values.
    /// </summary>
    public class LinkedList
    {
        /// The entry point of the list
        public LLNode start;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public LinkedList()
        {
        }

        /// <summary>
        /// Helper method that takes an int and adds it
        /// to the list in the form of a node
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            /// new node to be added
            LLNode newNode = new LLNode(value);

            /// If no nodes have been added yet set the
            /// start of the list to the new node
            if (this.start == null)
                this.start = newNode;

            /// A node has been added already, find
            /// the end of the chain
            else
            {
                /// Create a reference to the starting node
                LLNode traversalNode = this.start;

                /// Until we get to the end of the chain
                while (traversalNode.next != null)
                {
                    /// Move the reference to the next node
                    /// in the chain
                    traversalNode = traversalNode.next;
                }

                /// Once the while loop finishes, we will be
                /// at the end of the chain.

                /// Point the last node in the chain to the
                /// newly-created node, adding it to our chain
                traversalNode.next = newNode;
            }
        }

    }
}
