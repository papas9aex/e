using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp28
{

    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            List<int> list = new List<int>();
            HashSet<int> uniqueValues = new HashSet<int>();

            while (list.Count < 30)
            {
                int value = random.Next(0, 100);

                if (uniqueValues.Add(value))
                {
                    list.Add(value);
                }
            }

            int[] anArrayNodes = new int[30];

            for (int i = 0; i < anArrayNodes.Length; i++)
            {

                anArrayNodes[i] = list[i];
            }

            BST bst = new BST();

            for (int i = 0; i < anArrayNodes.Length; i++)
            {
                bst.insert(anArrayNodes[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("BINARY SEARCH TREE from random");
            // Visualize the BST
            bst.visualize();

            AVLTree avlTree = new AVLTree();

            for (int i = 0; i < anArrayNodes.Length; i++)
            {
                avlTree.insert(anArrayNodes[i]);
            }


            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("AVL BALANCED TREE from random");
            // Visualize the BST
            avlTree.visualize();

            BinaryHeap binaryHeap = new BinaryHeap();

            foreach (int i in anArrayNodes)
            {
                binaryHeap.Insert(i);
            }


            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("BINARY HEAP TREE from random");
            binaryHeap.Print();


            List<int> sorted_arr = new List<int>();

            foreach (int i in anArrayNodes)
            {
                sorted_arr.Add(binaryHeap.getElement(0));
                binaryHeap.Delete();
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("HEAP SORTED LIST from random");
            foreach (int i in sorted_arr)
            {
                Console.WriteLine(i);
            }
          
            Console.ReadLine();

        }
    }
}

