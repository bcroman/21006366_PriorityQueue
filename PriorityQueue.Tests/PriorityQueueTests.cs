using NUnit.Framework;
using PriorityQueue;
using System;
using System.Collections.Generic;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        // List of queue implementations to be tested
        private static IEnumerable<PriorityQueue<string>> GetQueues()
        {
            yield return new HeapPriorityQueue<string>(10);
            yield return new SortedArrayPriorityQueue<string>(10);
            yield return new UnsortedArrayPriorityQueue<string>(10);
            yield return new SortedLinkedPriorityQueue<string>(10);
            yield return new UnsortedLinkedPriorityQueue<string>(10);
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void Add_And_Head_ReturnsHighestPriorityItem(PriorityQueue<string> queue)
        {
            queue.Add("Task A", 2);
            queue.Add("Task B", 5);
            queue.Add("Task C", 3);

            // Act
            string result = queue.Head();

            // Assert
            Assert.That(result, Is.EqualTo("Task B"));
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void Remove_UpdatesHeadProperly(PriorityQueue<string> queue)
        {
            queue.Add("Task A", 2);
            queue.Add("Task B", 5);
            queue.Add("Task C", 3);

            queue.Remove();
            // Act
            string result = queue.Head();

            // Assert
            Assert.That(result, Is.EqualTo("Task C"));
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void IsEmpty_ReturnsTrue_WhenQueueIsEmpty(PriorityQueue<string> queue)
        {
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void IsEmpty_ReturnsFalse_WhenQueueHasItems(PriorityQueue<string> queue)
        {
            queue.Add("Task A", 2);
            Assert.That(queue.IsEmpty(), Is.False);
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void Remove_ThrowsException_WhenQueueIsEmpty(PriorityQueue<string> queue)
        {
            Assert.Throws<QueueUnderflowException>(() => queue.Remove());
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void Add_ThrowsException_WhenQueueIsFull(PriorityQueue<string> queue)
        {
            if (queue is HeapPriorityQueue<string> ||
                queue is SortedArrayPriorityQueue<string> ||
                queue is UnsortedArrayPriorityQueue<string> ||
                queue is SortedLinkedPriorityQueue<string> ||
                queue is UnsortedLinkedPriorityQueue<string>)
            {
                var smallQueue = new HeapPriorityQueue<string>(2);
                smallQueue.Add("Task A", 1);
                smallQueue.Add("Task B", 2);

                Assert.Throws<QueueOverflowException>(() => smallQueue.Add("Task C", 3));
            }
        }
    }
}
