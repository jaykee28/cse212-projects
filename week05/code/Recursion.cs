using System;
using System.Collections.Generic;
using System.Text;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; 
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            string remaining = letters.Replace(c.ToString(), "");
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs with memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int,int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int,int)>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        var directions = new List<(int dx, int dy)> { (1, 0), (0, 1), (-1, 0), (0, -1) };

        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        currPath.RemoveAt(currPath.Count - 1); // backtrack
    }
}

/// <summary>
/// Extension method to format paths as strings for test comparison
/// </summary>
public static class PathExtensions
{
    public static string AsString(this List<(int,int)> path)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<List>{");
        for (int i = 0; i < path.Count; i++)
        {
            sb.Append($"({path[i].Item1}, {path[i].Item2})");
            if (i < path.Count - 1)
                sb.Append(", ");
        }
        sb.Append("}");
        return sb.ToString();
    }
}
