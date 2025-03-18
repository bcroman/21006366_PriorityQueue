using NUnit.Framework;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class Class1
    {
        private HeapPriorityQueue<string> heapQueue;
        private SortedArrayPriorityQueue<string> sortedArrayQueue;
        private UnsortedArrayPriorityQueue<string> unsortedArrayQueue;
        private SortedLinkedPriorityQueue<string> sortedLinkedQueue;
        private UnsortedLinkedPriorityQueue<string> unsortedLinkedQueue;

        [SetUp]
        public void Setup()
        {
            heapQueue = new HeapPriorityQueue<string>(10);
            sortedArrayQueue = new SortedArrayPriorityQueue<string>(10);
            unsortedArrayQueue = new UnsortedArrayPriorityQueue<string>(10);
            sortedLinkedQueue = new SortedLinkedPriorityQueue<string>(10);
            unsortedLinkedQueue = new UnsortedLinkedPriorityQueue<string>(10);
        }

        [Test]
        public void Add_And_Head_ReturnsHighestPriorityItem()
        {
            heapQueue.Add("Task A", 2);
            heapQueue.Add("Task B", 5);
            heapQueue.Add("Task C", 3);

            // Act
            string result = heapQueue.Head();

            // Assert
            Assert.That(result, Is.EqualTo("Task B"));
        }
    }
}
