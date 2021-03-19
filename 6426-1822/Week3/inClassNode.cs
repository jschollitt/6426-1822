using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public class inClassNode
    {
        public int value;
        public inClassNode next;

        public inClassNode(int value)
        {
            this.value = value;
        }

        public bool Equals(inClassNode node)
        {
            if (this.value == node.value)
            {
                return true;
            }
            return false;
        }
    }
}
