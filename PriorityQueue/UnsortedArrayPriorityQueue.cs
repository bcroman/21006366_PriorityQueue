﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int count;

        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            count = 0;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = FindHighestPriorityIndex();
            return storage[highestPriorityIndex].Item;
        }

        public void Add(T item, int priority)
        {
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }
            storage[count] = new PriorityItem<T>(item, priority);
            count++;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = FindHighestPriorityIndex();

            // Replace the removed element with the last element to maintain continuity
            storage[highestPriorityIndex] = storage[count - 1];
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
                throw new QueueUnderflowException("No items to display");
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

        private int FindHighestPriorityIndex()
        {
            int highestPriorityIndex = 0;
            for (int i = 1; i < count; i++)
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;
                }
            }
            return highestPriorityIndex;
        }

    }
}
