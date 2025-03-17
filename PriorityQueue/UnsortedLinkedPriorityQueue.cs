using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Represents a priority quene using a unsorted linked list
    /// </summary>
    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>
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
        public UnsortedLinkedPriorityQueue(int size)
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
            // Check if the queue is empty
            if (IsEmpty())
            {
                throw new QueueUnderflowException(); //error message
            }

            Node current = head; //Set current from first node
            Node highest = head; //Set head from first node

            while (current != null) //Loop Through queue
            {
                if (current.Data.Priority > highest.Data.Priority) //check if current node is higher than highest value
                {
                    highest = current;
                }
                current = current.Next; //move to the next node
            }

            return highest.Data.Item;
        }

        /// <summary>
        /// Adds item to the tail of the linked list queue
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="priority">The priority of the item</param>
        /// <exception cref="QueueOverflowException">Thrown if the queue is full.</exception>
        public void Add(T item, int priority)
        {
            if (count >= capacity) //check if queue is full
            {
                throw new QueueOverflowException(); //Error Message
            }

            Node newNode = new Node(item, priority); //Create New Note

            // If the head note is empty, set head to the new node
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                //move the list to find the last node (tail)
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                // Add Note to the last position (tail)
                current.Next = newNode;
            }
            count++; //Increment count
        }

        /// <summary>
        /// Finds and removes item with highest priority of the queue
        /// </summary>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public void Remove()
        {
            if (IsEmpty()) //Check if queue is empty
            {
                throw new QueueUnderflowException(); //error message
            }

            Node current = head; //Set Current from first node
            Node highest = head; //Set head from first node
            //Keep track of node positions
            Node prev = null;
            Node highestPrev = null; 

            //Loop through queue
            while (current != null)
            {
                //check if current priority is higher then highest priority
                if (current.Data.Priority > highest.Data.Priority)
                {
                    highest = current;
                    highestPrev = prev; //Take note of previous position
                }
                prev = current; //move prev node forward
                current = current.Next; //move to next note
            }

            //Remove highest if it's head node
            if (highestPrev == null)
            {
                head = head.Next;
            }
            else //Remove highest if it's not head node
            {
                highestPrev.Next = highest.Next;
            }

            count--; //Decrease count
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
