using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree A = new BinaryTree();
            A.Add(50);
            A.Add(43);
            A.Add(59);
            A.Add(29);
            A.Add(47);
            A.Add(52);
            A.Add(67);
            A.Add(89);
            Console.WriteLine("Прямой обход дерева A:");
            A.GetNodesDirectly(A.root);
            Console.WriteLine();

            BinaryTree B = new BinaryTree();
            B.Add(70);
            B.Add(49);
            B.Add(80);
            B.Add(20);
            B.Add(62);
            B.Add(68);
            B.Add(92);
            Console.WriteLine();
            Console.WriteLine("Симметричный обход деревва B:");
            B.GetNodesSym(B.root);
            Console.WriteLine();

            BinaryTree C = new BinaryTree();
            C.Add(50);
            C.Add(43);
            C.Add(59);
            C.Add(29);
            C.Add(47);
            C.Add(52);
            C.Add(67);
            C.Add(89);
            B.AddNodesReverse(B.root, C);
            Console.WriteLine();
            Console.WriteLine("Прямой обход дерева С:");
            C.GetNodesDirectly(C.root);

            Console.ReadLine();
        }
    }
    class BinaryTree
    {
        public class Node
        {
            public int value;
            public Node leftChild;
            public Node rightBrother;
            public bool exist; // проверка на существовании данного узла 

            public Node(int value)
            {
                this.value = value;
                exist = true;
            }
        }

        public Node root;

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node temp = root;
            while (true)
            {
                if (value < temp.value)
                {
                    if (temp.leftChild == null)
                    {
                        temp.leftChild = new Node(value);
                        return;
                    }
                    else
                    {
                        if (!temp.leftChild.exist)
                        {
                            temp.leftChild.exist = true;
                            temp.leftChild.value = value;
                            return;
                        }
                        temp = temp.leftChild;
                    }
                }
                else if (value > temp.value)
                {
                    if (temp.leftChild == null)
                    {
                        temp.leftChild = new Node(0);
                        temp.leftChild.exist = false;
                    }
                    temp = temp.leftChild;

                    if (temp.rightBrother == null)
                    {
                        temp.rightBrother = new Node(value);
                        return;
                    }
                    else
                        temp = temp.rightBrother;
                }
                else
                    return;
            }
        }

        public void GetNodesDirectly(Node temp)
        {
            if (temp != null && temp.exist)
            {
                Console.Write(temp.value + " ");
                GetNodesDirectly(temp.leftChild);
                GetNodesDirectly(temp.rightBrother);
            }
            if (temp != null && !temp.exist)
            {
                GetNodesDirectly(temp.rightBrother);
            }
            else return;
        }

        public void AddNodesReverse(Node temp, BinaryTree C)
        {
            if (temp != null && temp.exist)
            {
                AddNodesReverse(temp.leftChild, C);
                C.Add(temp.value);
                AddNodesReverse(temp.rightBrother, C);
            }
            if (temp != null && !temp.exist)
            {
                AddNodesReverse(temp.rightBrother, C);
            }
            else return;
        }

        public void GetNodesSym(Node temp)
        {
            if (temp != null && temp.leftChild != null && temp.exist)
            {
                GetNodesSym(temp.leftChild);
                Console.Write(temp.value + " ");
                GetNodesSym(temp.leftChild.rightBrother);
            }

            if (temp != null && temp.leftChild == null && temp.exist)
            {
                Console.Write(temp.value + " ");
            }

            if (temp != null && !temp.exist)
            {
                return;
            }
        }
    }
}
