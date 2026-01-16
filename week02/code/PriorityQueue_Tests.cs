using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Highest priority item comes out first
    // Defect(s) Found: Fixed loop bounds and removed item logic in Dequeue
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        // Check dequeue order by priority
        Assert.AreEqual("B", pq.Dequeue()); // B has highest priority
        Assert.AreEqual("C", pq.Dequeue()); // Next highest
        Assert.AreEqual("A", pq.Dequeue()); // Last item
    }

    [TestMethod]
    // Scenario: Enqueue items with same high priority
    // Expected Result: FIFO order is preserved among items with same priority
    // Defect(s) Found: Corrected Dequeue to honor FIFO for items with same priority
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 3);

        // X and Y have same priority, X was added first
        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Ensure exception is thrown when queue is empty
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type {e.GetType()}: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue returns items from highest to lowest priority
    // Defect(s) Found: Dequeue logic must correctly remove the highest priority item
    public void TestPriorityQueue_Multiple()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("One", 2);
        pq.Enqueue("Two", 4);
        pq.Enqueue("Three", 3);
        pq.Enqueue("Four", 4);

        // Two and Four have same highest priority, Two added first
        Assert.AreEqual("Two", pq.Dequeue());
        Assert.AreEqual("Four", pq.Dequeue());
        Assert.AreEqual("Three", pq.Dequeue());
        Assert.AreEqual("One", pq.Dequeue());
    }
}
