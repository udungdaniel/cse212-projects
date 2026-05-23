using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // Problem 1:
        // Use a HashSet for O(1) lookup time.

        HashSet<string> seenWords = new();
        List<string> pairs = new();

        foreach (string word in words)
        {
            // Ignore words with identical letters like "aa"
            if (word[0] == word[1])
                continue;

            // Reverse the current word
            string reversed = $"{word[1]}{word[0]}";

            // Check if reversed word already exists
            if (seenWords.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }

            seenWords.Add(word);
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Degree is stored in column 4 (index 3)
            string degree = fields[3].Trim();

            // Count how many times each degree appears
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Problem 3:
        // Ignore spaces and letter casing.

        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Words must contain the same number of letters
        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> letterCounts = new();

        // Count letters from first word
        foreach (char letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        // Remove counts using second word
        foreach (char letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS).
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Problem 5:
        // Create formatted earthquake summaries.

        List<string> earthquakeSummaries = new();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double magnitude = feature.Properties.Mag;

            earthquakeSummaries.Add($"{place} - Mag {magnitude}");
        }

        return earthquakeSummaries.ToArray();
    }
}