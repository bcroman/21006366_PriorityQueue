# Priority Queue Program
Priority queue program is a C# program which is used the Software Construction Assessment 1. Was given the base program which had the windows form, Sorted Array Queue and other files to handle errors and Priority queue.\
The task was to create 4 other priority queue methods without using prebuild functions. 
- Unsort Array Queue
- Sort Linked Queue
- Unsort Linked Queue
- Max-heap Queue

The next part is to setup and create Nunit Testing file which would test all 5 queues on methods and error handling.

## Priority Queues
**Unsort Array Queue**\
Using the sorted array queue as a temple then edit to change add method to not sorted, created a FindHighest method to find highest Priority which would be used in the head and remove functions.\
**Sort Linked Queue**\
Created a node class for linked list data and using the Add,head,remove and isEmpty queue functions to mange the linked queue\
**Unsort Linked Queue**\
Using the sorted linked queue as a temple then edit to change add method to not sorted. also edited the head and remove function to find the highest priority.\
**Max-heap Queue**\
Created a Max Heap Queue which using an array to sort the items. Created HeapifyUp and HeapifyDown functions to mange sorting positions, and Swap Function to swap index positions.

## Testing
Created a project in the program which manges the Nunit Library and Test file. \
Added a reference to priority queue main.\
Edit the Test File to add 6 tests which runs on each queue which tests the head, remove, isEmpty and Error Handing functions.\
Passed: 30 out of 30\
The Test can be run by clicking on 'Test' tab and choosing run all tests.

### Info
Version 1\
18/03/2025\
21006266