using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Represents a priority quene using a unsort array
    /// </summary>
    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        //Variables
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int count;

        /// <summary>
        /// Initializes a new instance of the UnsortedArrayPriorityQueue class.
        /// </summary>
        /// <param name="size">The maximum number of elements the queue can hold.</param>
        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
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
                throw new QueueUnderflowException(); //Error  Message
            }

            int highestPriorityIndex = FindHighestPriorityIndex(); //Finds and set Highest Priority Index
            return storage[highestPriorityIndex].Item;
        }

        /// <summary>
        /// Adds Item to last position of the queue
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="priority">The priority of the ite</param>
        /// <exception cref="QueueOverflowException">Thrown if the queue is full.</exception>
        public void Add(T item, int priority)
        {
            if (count >= capacity) //Check the queue length
            {
                throw new QueueOverflowException(); //Error  Message
            }
            storage[count] = new PriorityItem<T>(item, priority); //Add iten to queue
            count++;
        }

        /// <summary>
        /// Removes Item with highest priority of the queue
        /// </summary>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public void Remove()
        {
            if (IsEmpty()) //Check if queue is empty
            {
                throw new QueueUnderflowException(); //Error  Message
            }

            int highestPriorityIndex = FindHighestPriorityIndex(); //Finds and set Highest Priority Index

            // Replace the removed element with the last element to maintain continuity
            storage[highestPriorityIndex] = storage[count - 1];
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
        /// Display Array Items
        /// </summary>
        /// <returns>Display a string value of array values</returns>
        public override string ToString()
        {
            if (IsEmpty()) //Check if queue is empty
            {
                throw new QueueUnderflowException("No items to display"); //Error  Message
            }

            //Loop through queue and display into a string format
            string result = "[";
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }

        /// <summary>
        /// Finds the Highest Priority item of the array
        /// </summary>
        /// <returns>the index of the item with the highest priority</returns>
        private int FindHighestPriorityIndex()
        {
            int highestPriorityIndex = 0;
            for (int i = 1; i < count; i++) //Loop through array
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority) //check if current index is higher than highest index
                {
                    highestPriorityIndex = i;
                }
            }
            return highestPriorityIndex;
        }

    }
}
