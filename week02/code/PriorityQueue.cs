using System;
using System.Collections.Generic;

/// <summary>
/// PriorityQueue class: maintains a queue where each item has a value and a priority.
/// Higher priority numbers are dequeued first. If multiple items have the same priority,
/// the item closest to the front (FIFO) is dequeued first.
/// </summary>
public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value with the highest priority.
    /// If multiple items have the same highest priority, the first one is removed.
    /// Throws InvalidOperationException if queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find index of the highest priority item (FIFO if tie)
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
        }

        // Remove and return the value
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    /// <summary>
    /// String representation of the queue.
    /// DO NOT MODIFY - used by graders.
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Internal class for storing a value and its priority
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY - used by graders
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
