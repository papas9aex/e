using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
  public  class BinaryHeap
    {
        public int[] heap;
        public int size;

        public BinaryHeap()
        {
            heap = new int[31];
            size = 0;
        }

        public void Insert(int item)
        {
            if (size == heap.Length)
            {
                ResizeHeap();
            }

            heap[size] = item;
            size++;
            ShiftUp(size - 1);
        }

        public int Delete()
        {
            if (size == 0)
            {

                throw new Exception("Heap is empty");
            }


            int root = heap[0];
            heap[0] = heap[size - 1];
            size--;
            ShiftDown(0);
            return root;
        }


        public void ShiftUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (parentIndex >= 0 && heap[parentIndex] < heap[index])
            {
                Swap(parentIndex, index);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        public void ShiftDown(int index)
        {
            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int largest = index;

                if (leftChildIndex < size && heap[leftChildIndex] > heap[largest])
                {
                    largest = leftChildIndex;
                }

                if (rightChildIndex < size && heap[rightChildIndex] > heap[largest])
                {
                    largest = rightChildIndex;
                }

                if (largest != index)
                {
                    Swap(largest, index);
                    index = largest;
                }
                else
                {
                    break;
                }
            }
        }

        public void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void ResizeHeap()
        {
            int[] newHeap = new int[heap.Length * 2];
            Array.Copy(heap, newHeap, heap.Length);
            heap = newHeap;
        }


        public void Print()
        {
            if (size == 0)
            {
                Console.WriteLine("PriorityQueue is empty.");
                return;
            }

            PrintNode(0, "");
        }


        public int getElement(int index)
        {
            return heap[index];
        }


        /// <summary>
        /// Отрисовка дерева
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="indent"></param>
        public void PrintNode(int index, string indent)
        {
            if (index < size)
            {
                Console.WriteLine(indent + heap[index]);

                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;

                if (leftChildIndex < size)
                {
                    Console.WriteLine(indent + "├── " + "Left Child:");
                    PrintNode(leftChildIndex, indent + "│   ");
                }

                if (rightChildIndex < size)
                {
                    Console.WriteLine(indent + "└── " + "Right Child:");
                    PrintNode(rightChildIndex, indent + "    ");
                }
            }

        }



        public int binarySearch(int target)
        {
            int left = 0;
            int right = size - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (heap[mid] == target)
                {
                    return mid; // Элемент найден
                }
                else if (heap[mid] < target)
                {
                    left = mid + 1; // Искомый элемент может находиться в правой половине
                }
                else
                {
                    right = mid - 1; // Искомый элемент может находиться в левой половине
                }
            }

            return -1;
            // Элемент не найден
        }
    }
}
