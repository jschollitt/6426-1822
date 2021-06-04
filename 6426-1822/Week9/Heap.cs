using System;
using System.Collections.Generic;
using System.Text;

namespace Week9
{
    class Heap
    {
        List<int> heapList;
        public Heap()
        {
            heapList = new List<int>();
        }

        public void reheapUp(int index)
        {
            if (index != 0)
            {
                int parentIndex = getParent(index);
                if (heapList[index] > heapList[parentIndex])
                {
                    int temp = heapList[index];
                    heapList[index] = heapList[parentIndex];
                    heapList[parentIndex] = temp;
                    reheapUp(parentIndex);
                }
            }
        }

        public void reheapDown(int root)
        {
            int left = getLeft(root);
            int right = getRight(root);
            
            if (heapList.Count > left) // left child exist
            {
                int biggestChild;
                if (heapList.Count > right) // right child exist
                {
                    biggestChild = heapList[left] > heapList[right] ? left : right;
                }
                else // right child does not exist
                {
                    biggestChild = left;
                }
                // if root smaller than biggest child: swap, recur
                if (heapList[root] < heapList[biggestChild])
                {
                    swap(root, biggestChild);
                    reheapDown(biggestChild);
                }
            }
        }

        public void insert(int value)
        {
            heapList.Add(value);
            reheapUp(heapList.Count - 1);
        }

        public int delete()
        {
            if (heapList.Count == 0)
                return -1;
            int removedValue = heapList[0];
            heapList[0] = heapList[heapList.Count - 1];
            heapList.RemoveAt(heapList.Count - 1);
            reheapDown(0);
            
            return removedValue;
        }

        private int getLeft(int index)
        {
            return 2 * index + 1;
        }

        private int getRight(int index)
        {
            return 2 * index + 2;
        }

        private int getParent(int index)
        {
            if (index % 2 == 1)// odd number = left
            {
                return (index - 1) / 2;
            }
            else
            {
                return (index - 2) / 2;
            }
        }
        private void swap(int a, int b)
        {
            int temp = heapList[a];
            heapList[a] = heapList[b];
            heapList[b] = temp;
        }

        public override string ToString()
        {
            return string.Join(',', heapList.ToArray());
        }
    }
}
