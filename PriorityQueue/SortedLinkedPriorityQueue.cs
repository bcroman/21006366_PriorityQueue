using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriorityQueue
{
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        private class Node
        {
            public PriorityItem<T> Data;
            public Node Next;

            public Node(T item, int priority)
            {
                Data = new PriorityItem<T>(item, priority);
                Next = null;
            }

        }

        private Node head;
        private int capacity;
        private int count;

        public SortedLinkedPriorityQueue(int size)
        {
            head = null;
            capacity = size;
            count = 0;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return head.Data.Item;
        }

        public void Add(T item, int priority)
        {
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            Node newNode = new Node(item, priority);

            if (head == null || head.Data.Priority < priority)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null && current.Next.Data.Priority >= priority)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            count++;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            head = head.Next;
            count--;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Queue is empty.";
            }

            Node current = head;
            string result = "[";
            while (current != null)
            {
                result += current.Data.ToString();
                if (current.Next != null)
                {
                    result += ", ";
                }
                current = current.Next;
            }
            result += "]";
            return result;
        }
    }
}
