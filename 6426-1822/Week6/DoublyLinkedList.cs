using System;
using System.Collections.Generic;
using System.Text;

namespace Week6
{
    public class DLNode
    {
        public DLNode forward;
        public DLNode backward;

        public int data;

        public DLNode()
        {
            this.forward = null;
            this.backward = null;
            this.data = 0;
        }

        public DLNode(int value) : this()
        {
            this.data = value;
        }
    }
    class DoublyLinkedList
    {
        public DLNode head;
        public DLNode end;

        public int count;

        public DoublyLinkedList()
        {
            this.head = null;
            this.end = null;
            this.count = 0;
        }

        public void Append(int data)
        {
            DLNode newnode = new DLNode(data);
            if (count == 0)
            {
                this.head = newnode;
                this.end = newnode;
            }
            else
            {
                this.end.forward = newnode;
                newnode.backward = this.end;
                this.end = newnode;
                this.count++;
            }
        }

        public void Insert(int data, DLNode insertAfter)
        {
            DLNode newnode = new DLNode(data);
            DLNode next = insertAfter.forward;
            insertAfter.forward = newnode;
            newnode.forward = next;
            next.backward = newnode;
            newnode.backward = insertAfter;
            this.count++;
        }

        public int Delete(DLNode deleteme)
        {
            DLNode prev = deleteme.backward;
            DLNode next = deleteme.forward;

            if (prev != null)
            {
                prev.forward = next;
            }
            if (next != null)
            {
                next.backward = prev;
            }
            ++this.count;
            return deleteme.data;
        }
    }
}
