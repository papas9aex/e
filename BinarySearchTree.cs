using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
  public  class BinarySearchTree
    {
        private TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int value)
        {
            root = InsertNode(root, value);
        }

        private TreeNode InsertNode(TreeNode node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Value)
                node.Left = InsertNode(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertNode(node.Right, value);

            return node;
        }

        public void PrintTree()
        {
            Console.WriteLine("Бинарное дерево поиска:");
            PrintNode(root);
            Console.WriteLine();
        }

        private void PrintNode(TreeNode node)
        {
            if (node != null)
            {
                PrintNode(node.Left);
                Console.Write(node.Value + " ");
                PrintNode(node.Right);
            }
        }

        public void BalanceTree()
        {
            var sortedList = new List<int>();
            InOrderTraversal(root, sortedList);
            root = BuildBalancedTree(sortedList, 0, sortedList.Count - 1);
        }

        private void InOrderTraversal(TreeNode node, List<int> sortedList)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, sortedList);
                sortedList.Add(node.Value);
                InOrderTraversal(node.Right, sortedList);
            }
        }

        private TreeNode BuildBalancedTree(List<int> sortedList, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            var node = new TreeNode(sortedList[mid]);

            node.Left = BuildBalancedTree(sortedList, start, mid - 1);
            node.Right = BuildBalancedTree(sortedList, mid + 1, end);

            return node;
        }
    }

}
