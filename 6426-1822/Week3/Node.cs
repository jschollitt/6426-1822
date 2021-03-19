using System;
using System.Collections.Generic;
using System.Text;

namespace Week3
{
    public interface INode<T>
    {
        public T value 
        { 
            get; 
            set; 
        }
        public INode<T> next 
        { 
            get; 
            set; 
        }

        public string ToString();

        public bool Equals();
    }
}
