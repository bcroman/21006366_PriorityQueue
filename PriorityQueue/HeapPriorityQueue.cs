using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Represents a priority quene using a binary max heap
    /// </summary>
    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        //Variables
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int count;

        /// <summary>
        /// Initializes a new instance of the HeapPriorityQueue class.
        /// </summary>
        /// <param name="size">The maximum number of elements the queue can hold.</param>
        public HeapPriorityQueue(int size)
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

            return storage[0].Item;
        }

        /// <summary>
        /// Adds Item to the queue
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="priority">The priority of the ite</param>
        /// <exception cref="QueueOverflowException">Thrown if the queue is full.</exception>
        public void Add(T item, int priority)
        {
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            // Insert new element at the end
            storage[count] = new PriorityItem<T>(item, priority);
            count++;

            // Call Heapify up Method
            HeapifyUp(count - 1);
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
        /// Removes Item with highest priority of the queue
        /// </summary>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty.</exception>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            // Replace root with the last element
            storage[0] = storage[count - 1];
            count--;

            // Class Heapify Down Method
            HeapifyDown(0);
        }

        /// <summary>
        /// Display Array Items
        /// </summary>
        /// <returns>Display a string value of array values</returns>
        public override string ToString()
        {
            if (IsEmpty()) //Check if queue is empty
            {
                return "No Items in Queue!";
            }

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
        /// Moves a new added element upward on the tree
        /// </summary>
        /// <param name="index">Index position for item</param>
        private void HeapifyUp(int index)
        {
            while (index > 0) // Continue until reaching the root
            {
                int parentIndex = (index - 1) / 2; // Calculate parent index

                if (storage[index].Priority <= storage[parentIndex].Priority)
                {
                    break; // Stop if heap property is satisfied
                }

                // Swap with parent to move up the heap
                Swap(index, parentIndex);
                index = parentIndex; // Update index to continue moving up
            }
        }

        /// <summary>
        /// Update the root element and move other elements after root is deleted
        /// </summary>
        /// <param name="index">Index position for item</param>
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int largest = index;

                // Compare left child
                if (leftChild < count && storage[leftChild].Priority > storage[largest].Priority)
                {
                    largest = leftChild;
                }

                // Compare right child
                if (rightChild < count && storage[rightChild].Priority > storage[largest].Priority)
                {
                    largest = rightChild;
                }

                // Stop if heap property is maintained
                if (largest == index)
                {
                    break;
                }

                // Swap with the largest child
                Swap(index, largest);
                index = largest; // Move down
            }
        }

        /// <summary>
        /// Swaps the frist and second item positions
        /// </summary>
        /// <param name="index1">Index position for frist item</param>
        /// <param name="index2">Index position for second item</param>
        private void Swap(int index1, int index2)
        {
            PriorityItem<T> temp = storage[index1]; // Store first item in temp
            storage[index1] = storage[index2]; // Move second item to first position
            storage[index2] = temp; // Move temp to second position
        }
    }
}
