public static class Arrays
{
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. 
    /// For example: 
    /// List<int>{1,2,3,4,5,6,7,8,9} rotated by 5 → {5,6,7,8,9,1,2,3,4}
    /// List<int>{1,2,3,4,5,6,7,8,9} rotated by 3 → {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the size of the list
        int n = data.Count;

        // Step 2: Handle the case where amount is equal to the list size
        // Rotating by n or multiples of n gives the same list
        amount = amount % n;

        // Step 3: Get the last 'amount' elements of the list using GetRange
        List<int> endPart = data.GetRange(n - amount, amount);

        // Step 4: Remove these last 'amount' elements from the original list
        data.RemoveRange(n - amount, amount);

        // Step 5: Insert the saved elements at the beginning of the list
        data.InsertRange(0, endPart);

        // Step 6: The list is now rotated to the right by 'amount'
    }
}
