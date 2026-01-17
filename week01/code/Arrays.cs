using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Part 1: MultiplesOf function
    /// </summary>
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create an array to store the multiples
        double[] multiples = new double[count];

        // Step 2: Loop from 0 to count - 1
        for (int i = 0; i < count; i++)
        {
            // Step 3: Compute the multiple and store it
            multiples[i] = start * (i + 1);
        }

        // Step 4: Return the array of multiples
        return multiples;
    }

    /// <summary>
    /// Part 2: Rotate a list to the right by a given amount
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int n = data.Count;
        amount = amount % n;                       // Normalize amount
        List<int> endPart = data.GetRange(n - amount, amount);  // Slice last elements
        data.RemoveRange(n - amount, amount);      // Remove from original list
        data.InsertRange(0, endPart);              // Insert at beginning
    }
}
