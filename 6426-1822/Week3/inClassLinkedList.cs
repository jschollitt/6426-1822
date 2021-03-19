using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public class inClassLinkedList
    {
        public inClassNode head;
        public int max = 0;
        public int min = 0;
        public int length = 0;

        public inClassLinkedList()
        {
        }

        public inClassLinkedList(int value)
        {
            inClassNode tempNode = new inClassNode(value);
            this.head = tempNode;
        }

        public void AddNode(int value)
        {
            // added node here

            if (value > max) max = value;
            if (value < min) min = value;
            ++length;
        }
    }
}
