using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    
    class LinkedList
    {
        public Node head;

        public LinkedList() { }

        public void Addnode(int value)
        {
            Node newNode = new Node(value);

            if (this.head == null) this.head = newNode;
            else
            {
                Node trav = this.head;
                while (trav.next != null) trav = trav.next;
                trav.next = newNode;
            }
        }

        public Node searchNode(int v)
        {
            Node trav = head;

            while (trav != null)
            {
                // check values
                if (trav.value == v)
                    return trav;
                // traverse
                trav = trav.next;
            }
            return null;
        }

        public void DeleteTemp()
        {
            Node trav = this.head;
            Node trailingtrav = this.head;

            trailingtrav = trav;
            trav = trav.next;

        }
    }
}
