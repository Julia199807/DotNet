using System;

namespace Laba1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //CheckList();
            CheckTree();
        }

        private static void CheckList()
        {
            // DoublyLinkedList<String> linkedList = new DoublyLinkedList<String>();
// добавление элементов
            var linkedList = new DoubleLinkedList<int>();
            linkedList.Add(4);
            linkedList.Add(3);
            linkedList.Add(9);
            
            linkedList.Add(1);

            // linkedList.AddFirst(2);
            
            linkedList.Output();

            linkedList.Remove(3);

            linkedList.Output();
            
            linkedList.Sort();
            
            linkedList.Output();
            
            linkedList.Add(2);
            
            linkedList.Output();
            
            linkedList.Sort();
            
            linkedList.Output();

        }


        private static void CheckTree()
        {
            var binaryTree = new Tree<int>();
        
            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            //Console.ReadLine();
            
            
        }


    }
}