using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PriorityQueue
{
    /// <summary>
    /// Represents a priority quene using a sorted linked list
    /// </summary>
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        /// <summary>
        /// Represents a node in the linked list.
        /// </summary>
        private class Node
        {
            public PriorityItem<T> Data; //Store data
            public Node Next; //Pointer

            /// <summary>
            /// Initializes a new instance of the Node class.
            /// </summary>
            /// <param name="item">The item to be stored.</param>
            /// <param name="priority">The priority of the item.</param>
            public Node(T item, int priority)
            {
                Data = new PriorityItem<T>(item, priority);
                Next = null;
            }

        }

        //Variables
        private Node head;
        private int capacity;
        private int count;

        /// <summary>
        /// Initializes a new instance of the SortedLinkedPriorityQueue class.
        /// </summary>
        /// <param name="size">The maximum number of elements the queue can hold.</param>
        public SortedLinkedPriorityQueue(int size)
        {
            head = null;
            capacity = size;
            count = 0;
        }

        /// <summary>
        /// Finds and Returns the item with the highest priority
        /// </summary>
        /// <returns>The item with the highest priority.</returns>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public T Head()
        {
            if (IsEmpty()) //Check if queue is empty
            {
                throw new QueueUnderflowException(); //error message
            }
            return head.Data.Item;
        }

        /// <summary>
        /// Adds and sorted item to correct position of the linked list queue
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="priority">The priority of the item</param>
        /// <exception cref="QueueOverflowException">Thrown if the queue is full.</exception>
        public void Add(T item, int priority)
        {
            if (count >= capacity) //check if queue is full
            {
                throw new QueueOverflowException(); //error message
            }

            Node newNode = new Node(item, priority); //create new node 

            if (head == null || head.Data.Priority < priority) //check if list is empty or current priority is higger than head node
            {
                //point and update new node to head
                newNode.Next = head; 
                head = newNode;
            }
            else 
            {
                //move the list to find the correct position for the new node
                Node current = head;
                while (current.Next != null && current.Next.Data.Priority >= priority)
                {
                    current = current.Next;
                }
                //add node to the correct position
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            count++; //Increment count
        }

        /// <summary>
        /// Removes Item with highest priority of the queue
        /// </summary>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public void Remove()
        {
            if (IsEmpty()) // Check if queue is empty
            {
                throw new QueueUnderflowException(); //error message
            }
            //Remove node and decrement count
            head = head.Next;
            count--;
        }

        /// <summary>
        /// Check if queue has items or not.
        /// </summary>
        /// <returns>True or false base if queue is empty</returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Display Lisked List Items
        /// </summary>
        /// <returns>Display a string value of linked values</returns>
        public override string ToString()
        {
            if (IsEmpty()) //check if queue is empty
            {
                return "Queue is empty."; //error message
            }

            //Loop through queue and display into a string format
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
