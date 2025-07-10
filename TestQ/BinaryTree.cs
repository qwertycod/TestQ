using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestQ
{
    // srouce -  bro code DSA - https://youtu.be/CBYHwZcbD-s?t=13350
    public class BinarySearchTree
    {
        NodeBT root;
        public void Insert(NodeBT node)
        {
            root = InsertHelper(root, node);
        }

        private NodeBT InsertHelper(NodeBT root, NodeBT node)
        {
            int data = node.data;

            if (root == null) {
                root = node;
                return node;
            }
            else if (data < root.data) {
                root.left = InsertHelper(root.left, node);
            }
            else
            {
                root.right = InsertHelper(root.right, node);
            }

            return root;
        }
        public void Display()
        {
            displayHelper(root);
        }

        private void displayHelper(NodeBT root)
        {
            if (root != null) {
                displayHelper(root.left);
                Console.WriteLine(root.data);
                displayHelper(root.right);
            }
        }

        public bool Search(int data)
        {
            return Searchelper(root, data);
        }

        private bool Searchelper(NodeBT root, int data)
        {
            if (root == null)
            {
                return false;
            }
            else if(root.data == data)
            {
                return true;
            }
            else if (data < root.data)
            {
                return Searchelper(root.left, data);
            }
            else if (data > root.data)
            {
                return Searchelper(root.right, data);
            }
            return false;
        }

        public void Remove(int data)
        {
            if (Search(data))
            {
                RemoveHelper(root, data);
            }
        }

        private NodeBT RemoveHelper(NodeBT root, int data)
        {
            if(root == null)
            {
                return root;
            }
            else if(root.data < data)
            {
                return RemoveHelper(root.right, data);
            }
            else if (root.data > data)
            {
                return RemoveHelper(root.left, data);
            }
            else    // found the node
            {
                if((root.left == null) && (root.right == null))
                {
                    root = null;
                }
                else if ( root.right != null)
                {
                    root.data = Successor(root);
                    root.right = RemoveHelper(root.left, data);
                }
                else if (root.left != null)
                {
                    root.data = Predecessor(root);
                    root.right = RemoveHelper(root.left, data);
                }
            }
            return null;
        }
        private int Successor(NodeBT root)
        {
            root = root.right;
            while (root.left != null) {
                root = root.left;
            }   
            return root.data;
        }

        private int Predecessor(NodeBT root)
        {
            root = root.left;
            while (root.right != null)
            {
                root = root.right;
            }
            return root.data;
        }

    }

    public class NodeBT
    {
        public int data;
        public NodeBT left;
        public NodeBT right;

        public NodeBT(int data)
        {
            this.data = data;
        }
    }
}
