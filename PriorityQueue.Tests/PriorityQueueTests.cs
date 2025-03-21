using NUnit.Framework;
using PriorityQueue;
using System;
using System.Collections.Generic;

namespace PriorityQueue.Tests
{
    /// <summary>
    ///  Tests Scrpt that checks each function and error handling for each queue method
    /// </summary>
    [TestFixture]
    public class PriorityQueueTests
    {
        // Create objects for all 5 queues
        private static IEnumerable<PriorityQueue<string>> GetQueues()
        {
            yield return new HeapPriorityQueue<string>(10);
            yield return new SortedArrayPriorityQueue<string>(10);
            yield return new UnsortedArrayPriorityQueue<string>(10);
            yield return new SortedLinkedPriorityQueue<string>(10);
            yield return new UnsortedLinkedPriorityQueue<string>(10);
        }

        //This tests the queue  by finding the highest proioruty item, by calling the head method
        [Test, TestCaseSource(nameof(GetQueues))]
        public void Add_And_Head_ReturnsHighestPriorityItem(PriorityQueue<string> queue)
        {
            //Input Data
            queue.Add("Task A", 2);
            queue.Add("Task B", 5);
            queue.Add("Task C", 3);

            //Call Head Method and Set to Result value
            string result = queue.Head();

            //Checks if the output is 'Task B'
            Assert.That(result, Is.EqualTo("Task B"));
        }

        //This tests removes the root item and checks if the head is updated
        [Test, TestCaseSource(nameof(GetQueues))]
        public void Remove_UpdatesHeadProperly(PriorityQueue<string> queue)
        {
            //Input Data
            queue.Add("Task A", 2);
            queue.Add("Task B", 5);
            queue.Add("Task C", 3);

            //Call Remove Methed
            queue.Remove();
            
            //Call Head Method and Set to Result value
            string result = queue.Head();

            //Checks if the output is 'Task C'
            Assert.That(result, Is.EqualTo("Task C"));
        }

        //Tests if the queue is empty
        [Test, TestCaseSource(nameof(GetQueues))]
        public void IsEmpty_ReturnsTrue_WhenQueueIsEmpty(PriorityQueue<string> queue)
        {
            //Calls isEmpty Methiods and checks if output is True
            Assert.That(queue.IsEmpty(), Is.True);
        }

        //Tests if the queue is empty with Add Data
        [Test, TestCaseSource(nameof(GetQueues))]
        public void IsEmpty_ReturnsFalse_WhenQueueHasItems(PriorityQueue<string> queue)
        {
            queue.Add("Task A", 2); //Input Data

            Assert.That(queue.IsEmpty(), Is.False); //Calls isEmpty Methiods and checks if output is False
        }

        //Checks if removes methond display error if queue is empty
        [Test, TestCaseSource(nameof(GetQueues))]
        public void Remove_ThrowsException_WhenQueueIsEmpty(PriorityQueue<string> queue)
        {
            Assert.Throws<QueueUnderflowException>(() => queue.Remove()); //Calls and Check Remove Methond
        }

        //Checks if Queue is Full
        [Test, TestCaseSource(nameof(GetQueues))]
        public void Add_ThrowsException_WhenQueueIsFull(PriorityQueue<string> queue)
        {
            //Checks if each queue has a fix size
            if (queue is HeapPriorityQueue<string> ||
                queue is SortedArrayPriorityQueue<string> ||
                queue is UnsortedArrayPriorityQueue<string> ||
                queue is SortedLinkedPriorityQueue<string> ||
                queue is UnsortedLinkedPriorityQueue<string>)
            {
                var smallQueue = new HeapPriorityQueue<string>(2); //Updates size to 2 items

                //Input Data
                smallQueue.Add("Task A", 1);
                smallQueue.Add("Task B", 2);

                //Trys to Add another item to queue by gets a error message.
                Assert.Throws<QueueOverflowException>(() => smallQueue.Add("Task C", 3));
            }
        }
    }
}
