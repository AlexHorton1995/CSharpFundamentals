using System;
using LinkedListLogic.ListClasses;

/// <summary>
//  Program: LinkedListLogic
/// </summary>
/// 
/// <remarks>
/// The purpose of this console application is to grasp the concept of Linked Lists
/// in C#.  The greater concept is to understand Algorithms and Data Structures.
/// </remarks>
namespace LinkedListLogic
{
    class Program
    {
        //implement our singly linked list here
        static Node<int> mainNode;

        //implement our doubly linked list here
        static DoublyLinkedNode<int> doubleNode;

        static void Main(string[] args)
        {
            
            mainNode = new Node<int>(1); //implementation of a root node.
            mainNode.Next = new Node<int>(2); //making first link in the chain.
            mainNode.Next.Next = new Node<int>(3); //making second link in the chain.

            doubleNode = new DoublyLinkedNode<int>(1); //root node
            doubleNode.Next = new DoublyLinkedNode<int>(2); //next link in chain
            doubleNode.Previous = null;

            doubleNode.Next.Next = new DoublyLinkedNode<int>(3); //third Link in chain
            doubleNode.Next.Previous = doubleNode;
            
            doubleNode.Next.Next.Next = new DoublyLinkedNode<int>(4);
            doubleNode.Next.Next.Previous = doubleNode.Next;

                        
            //display singly linked list nodes
            Console.WriteLine(mainNode.Value); //should be 1
            Console.WriteLine(mainNode.Next.Value); //should be 2
            Console.WriteLine(mainNode.Next.Next.Value); //should be 3

            Console.WriteLine();

            Console.WriteLine(doubleNode.Value); //should be 1
            Console.WriteLine(doubleNode.Next.Value); //should be 2
            Console.WriteLine(doubleNode.Next.Next.Value); //should be 3
            Console.WriteLine(doubleNode.Next.Next.Previous.Value); //should be 2

            Console.ReadLine();

        }
    }
}
