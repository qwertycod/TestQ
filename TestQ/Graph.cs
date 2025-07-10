using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQ.Graphs
{
    // Adjacency list graph by Bro code - https://youtu.be/CBYHwZcbD-s?t=11251

    // Adjacency list = An array/arrayList of linkedlist.
    public class Graph
    {
        ArrayList arrayList = new ArrayList();

        public Graph()
        {
            //arrayList = new ArrayList<>();
        }

        public void AddNode(Node1 node)
        {
            LinkedList<Node1> currentList = new LinkedList<Node1>();
            currentList.AddLast(node);
            arrayList.Add(currentList);
        }

        public void AddEdge(int src, int dst)
        {
            LinkedList<Node1> currentList = (LinkedList<Node1>)arrayList[src];
            LinkedList<Node1> dstNode = (LinkedList<Node1>)arrayList[dst];
            Node1 node = dstNode.First.Value;
            currentList.AddLast(node);
        }
        public bool CheckEdge(int src, int dst)
        {
            LinkedList<Node1> currentList = (LinkedList<Node1>)arrayList[src];
            LinkedList<Node1> dstNode = (LinkedList<Node1>)arrayList[dst];
            Node1 node = dstNode.First.Value;
            var res = currentList.Find(node);
            return res != null;
        }

        public void Print()
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                foreach(Node1 node1 in (LinkedList < Node1 > )arrayList[i])
                {
                    Console.Write(node1.data + " -> ");
                }
                Console.WriteLine();
            }
        }
    }

}
