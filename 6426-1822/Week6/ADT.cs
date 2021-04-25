using System;
using System.Collections.Generic;
using System.Text;

namespace Week6
{
    class ADTNode
    {
        ADTNode link;
        int data;

        public ADTNode(int value)
        {
            this.link = null;
            this.data = value;
        }
    }
    class ADT
    {
        ADTNode head;
        int count;

        public ADT()
        {
            this.head = null;
            this.count = 0;
        }
    }
}
