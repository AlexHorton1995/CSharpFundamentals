using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLogic.ListClasses
{
    /// <summary>
    /// Singly Linked Node Class
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    class Node<TNode>
    {
        public Node<TNode> Next;
        public TNode Value;

        public Node(TNode value, Node<TNode> next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    class DoublyLinkedNode<TDNode>
    {
        public DoublyLinkedNode<TDNode> Next;
        public DoublyLinkedNode<TDNode> Previous;
        public TDNode Value;

        public DoublyLinkedNode(TDNode value, 
            DoublyLinkedNode<TDNode> next = null, DoublyLinkedNode<TDNode> previous = null)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
    }

}
