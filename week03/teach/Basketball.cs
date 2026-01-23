using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        // Dictionary to store total points per player
        var players = new Dictionary<string, int>();

        // Open the CSV file
        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip header row

        // Read each line and accumulate points
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0]; // Column 0: Player ID
            var points = int.Parse(fields[8]); // Column 8: Points

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points; // Add points for this season
            }
            else
            {
                players[playerId] = points; // First season for this player
            }
        }

        // Sort the players by total points descending and take top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .Select(p => $"{p.Key} ({p.Value})")
            .ToArray();

        // Display results
        Console.WriteLine("Top 10 Players by Career Points:");
        foreach (var player in topPlayers)
        {
            Console.WriteLine(player);
        }
    }
}
