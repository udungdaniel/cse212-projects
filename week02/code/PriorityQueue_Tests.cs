using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and remove the item
    // with the highest priority.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found: The queue was not checking all items correctly and
    // sometimes failed to return the highest priority item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The first item added with the highest priority
    // should be removed first following FIFO order.
    // Defect(s) Found: The queue removed the most recently added item
    // instead of preserving FIFO order for equal priorities.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Remove an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown
    // with the message "The queue is empty."
    // Defect(s) Found: Verified that the correct exception and message
    // are required when the queue is empty.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Remove multiple items and verify they are removed
    // in correct priority order.
    // Expected Result: Items should be removed from highest priority
    // to lowest priority.
    // Defect(s) Found: Items were not being removed from the queue
    // after dequeueing.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}