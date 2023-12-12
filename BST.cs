using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class BST
    {
        BSTNode root;

        public void insert(int key)
        {
            root = insertHelper(root, key);
        }

        BSTNode insertHelper(BSTNode root, int key)
        {
            if (root == null)
            {
                return new BSTNode(key);
            }

            if (key < root.key)
            {
                root.left = insertHelper(root.left, key);
            }
            else if (key > root.key)
            {
                root.right = insertHelper(root.right, key);
            }

            return root;
        }

        public void visualize()
        {
            visualizeHelper(root, " ", true);
        }

        private void visualizeHelper(BSTNode node, String prefix, bool isLeft)
        {
            if (node == null)
            {
                return;
            }

            String nodeStr = node.key.ToString();
            String line = prefix + (isLeft ? "├── " : "└── ");
            Console.WriteLine(line + nodeStr);

            String childPrefix = prefix + (isLeft ? "│   " : "    ");
            visualizeHelper(node.left, childPrefix, true);
            visualizeHelper(node.right, childPrefix, false);
        }

        public void inOrderTraversal()
        {
            inOrderTraversalHelper(root);
            Console.WriteLine();
            //   System.out.println();
        }

        private void inOrderTraversalHelper(BSTNode node)
        {
            if (node != null)
            {
                inOrderTraversalHelper(node.left);
                Console.WriteLine(node.key + " ");
                inOrderTraversalHelper(node.right);
            }
        }

        public void preOrderTraversal()
        {
            preOrderTraversalHelper(root);
            //  System.out.println();
        }

        public void preOrderTraversalHelper(BSTNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.key + " ");
                preOrderTraversalHelper(node.left);
                preOrderTraversalHelper(node.right);
            }
        }
    }
}
