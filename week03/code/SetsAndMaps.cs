using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric pairs of two-character words using sets
    /// Optimized for O(n) time
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue; // skip identical letters like "aa"

            string reversed = new string(new char[] { word[1], word[0] });

            if (set.Contains(reversed))
            {
                result.Add($"{reversed} & {word}"); // reversed first for canonical order
                set.Remove(word);       // remove current
                set.Remove(reversed);   // remove reverse to avoid duplicates
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from a CSV file
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Check if two words are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) return false;

        var count = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (count.ContainsKey(c))
                count[c]++;
            else
                count[c] = 1;
        }

        foreach (var c in word2)
        {
            if (!count.ContainsKey(c)) return false;

            count[c]--;
            if (count[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Earthquake daily summary
    /// </summary>
    public class FeatureCollection
    {
        public Feature[] Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag ?? 0;
            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}
