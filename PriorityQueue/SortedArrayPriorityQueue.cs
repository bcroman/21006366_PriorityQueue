using System;

namespace PriorityQueue
{
    /// <summary>
    /// Represents a priority quene using a sorted array
    /// </summary>
    public class SortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        //Variables
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        /// <summary>
        /// Initializes a new instance of the SortedArrayPriorityQueue class.
        /// </summary>
        /// <param name="size">The maximum number of elements the queue can hold.</param>
        public SortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        /// <summary>
        /// Returns the item with the highest priority
        /// </summary>
        /// <returns>The item with the highest priority.</returns>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return storage[0].Item;
        }

        /// <summary>
        /// Adds Item to queue and finds the right position for it
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="priority">The priority of the ite</param>
        /// <exception cref="QueueOverflowException">Thrown if the queue is full.</exception>
        public void Add(T item, int priority)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            int i = tailIndex;
            while (i > 0 && storage[i - 1].Priority < priority)
            {
                storage[i] = storage[i - 1];
                i--;
            }
            storage[i] = new PriorityItem<T>(item, priority);
        }

        /// <summary>
        /// Removes Item with highest priority of the queue
        /// </summary>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            for (int i = 0; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }
            tailIndex--;
        }

        /// <summary>
        /// Check if queue has items or not.
        /// </summary>
        /// <returns>True or false base if queue is empty</returns>
        public bool IsEmpty()
        {
            return tailIndex < 0;
        }

        /// <summary>
        /// Display Array Items
        /// </summary>
        /// <returns>Display a string value of array values</returns>
        public override string ToString()
        {
            if (IsEmpty())
            {
                return "No Items in Queue!";
            }

            string result = "[";
            for (int i = 0; i <= tailIndex; i++)
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
    }
}
